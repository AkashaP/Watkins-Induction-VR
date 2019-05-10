using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour {

    public static bool debugMode = true;
    public static float timeToCompleteObjective = 2.5f;
    public static float lookAtThreshold = .05f;
    public TargetIndicator2 targetIndicator;
    //public static string completedMessage1 = "Well done, you have completed induction for the ";
    //public static string completedMessage2 = ". Move on to the next machine by staring at a link for the next machine";
    //public static string completedMessage2 = ". You have finished induction for all machines";
    public ObjectiveEntry[] objectives;
    public TextMeshProUGUI guideText;
    public string name;
    public static float currentTimer { get; private set; }
    public int currentObjective { get; private set; }
    public bool completed { get; private set; }
    private Camera camera;
    public AudioSource audioSource;
    public GameObject machineObject;
    private Animator machineAnimator;
    private int playedSound = 0;

    // Use this for initialization
    void Start () {
        camera = Camera.main;
        machineAnimator = machineObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ObjectiveEntry objectiveEntry = objectives[currentObjective];
        GameObject node = objectiveEntry.referencedNode;

        if (objectives[currentObjective].audioClips != null && playedSound < objectives[currentObjective].audioClips.Length)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = objectives[currentObjective].audioClips[playedSound];
                audioSource.Play();
                playedSound++;
            }
        }

        if (node == null) {
            currentTimer += Time.deltaTime;
            //Debug.Log(currentTimer);
            if (currentTimer >= objectiveEntry.secondsActive || (debugMode && Input.GetKeyDown(KeyCode.Space)))
            {
                currentTimer = 0;
                if (currentObjective < objectives.Length - 1)
                {
                    currentObjective++;
                    Refresh();
                   // if (objectives[currentObjective].audioClipStart != null)
                   //     audioSource.PlayOneShot(objectives[currentObjective].audioClipStart);
                }
                if (currentObjective >= objectives.Length - 1)
                    completed = true;
            }
        }
        else {
            Vector3 lookAt = camera.WorldToViewportPoint(node.transform.position);
            if (debugMode && Input.GetKeyDown(KeyCode.Space)) {
                IncrementObjective();
            }
            else
            if (lookAt.x >= 0.5f - lookAtThreshold &&
                lookAt.x <= 0.5f + lookAtThreshold &&
                lookAt.y >= 0.5f - lookAtThreshold &&
                lookAt.y <= 0.5f + lookAtThreshold)
            {
               // if (objectives[currentObjective].audioClipActive != null && !playedSound) {
                //    audioSource.PlayOneShot(objectives[currentObjective].audioClipActive);
                //    playedSound = true;
               // }
                currentTimer += Time.deltaTime;
                float completedness = Objectives.currentTimer / Objectives.timeToCompleteObjective;
                CompletionColourIndicator.completeness = completedness;
                if (currentTimer >= timeToCompleteObjective)
                {
                    IncrementObjective();
                    CompletionColourIndicator.completeness = 0;
                }
            } else
            {
                currentTimer = 0;
                CompletionColourIndicator.completeness = 0;
            }
        }
    }

    private void IncrementObjective()
    {
        currentTimer = 0;
        if (currentObjective < objectives.Length)
        {
            currentObjective++;
            Refresh();
        }
        if (currentObjective >= objectives.Length)
            completed = true;
    }

    private void Refresh()
    {
        foreach (ObjectiveEntry e in objectives)
        {
            if (e.referencedNode != null)
                e.referencedNode.SetActive(false);
        }
        if (objectives[currentObjective].referencedNode != null)
        {
            objectives[currentObjective].referencedNode.SetActive(true);
            targetIndicator.focus = objectives[currentObjective].referencedNode;
        }
        if (objectives[currentObjective].animationMode != -1)
        {
            machineAnimator.SetInteger("mode", objectives[currentObjective].animationMode);
        }
        playedSound = 0;
        guideText.SetText(objectives[currentObjective].dialogueLines);
    }

    void OnDisable()
    {
        Debug.Log("reset objectives of "+ name);
    }

    void OnEnable()
    {
        currentObjective = 0;
        Refresh();
    }

    [System.Serializable]
    public class ObjectiveEntry
    {
        [Tooltip("Line of dialogue for the current objective")]
        public string dialogueLines;
        [Tooltip("Waypoint indicator for objective (optional)")]
        public GameObject referencedNode;
        [Tooltip("If greater than 0, dialogue stays for a length of time, else it completes by looking at objective nodes")]
        public float secondsActive = -1;
        [Tooltip("Played when this objective entry is started")]
        public AudioClip audioClipStart;
        [Tooltip("Played as the node is being looked at")]
        public AudioClip audioClipActive;
        [Tooltip("Played in order when this objective entry is started")]
        public AudioClip[] audioClips;
        [Tooltip("Played when the node is activated, or -1 for no mode change")]
        public int animationMode = -1;
    }
}
