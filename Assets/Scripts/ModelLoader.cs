using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * When stared at, this will change the scene
 */
public class ModelLoader : MonoBehaviour {

    public bool initiallyActive = false;
    public OnlyOneActive machineRoot;
    public static float timeToActivate = 2f;
    public static float lookAtThreshold = 0.05f;
    public GameObject activator;
    private float lookTime;
    private bool currentlyActive = false;
    public Camera cam;
    public Sprite defaultSprite;
    public Sprite hoveringSprite;

	// Use this for initialization
	void Start () {
        if (initiallyActive)
            LoadModel();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 lookAt = cam.WorldToViewportPoint(gameObject.transform.position);
        //if (!currentlyActive)
        //Debug.Log(lookAt+transform.parent.gameObject.name);
        if (lookAt.x >= 0.5f - lookAtThreshold &&
            lookAt.x <= 0.5f + lookAtThreshold &&
            lookAt.y >= 0.5f - lookAtThreshold &&
            lookAt.y <= 0.5f + lookAtThreshold)
            // TODO need to test lookAt.z because might be looking in reverse direction or something
            // check for something like isVisibleOnScreen()
        {
            LoadModel();
        }
        if (activator.active)
        {
            currentlyActive = true;
            GetComponent<Image>().sprite = hoveringSprite;
        }
        else
        {
            currentlyActive = false;
            GetComponent<Image>().sprite = defaultSprite;
        }
    }

    void LoadModel()
    {
        machineRoot.SetOneActive(activator); currentlyActive = true; GetComponent<Image>().sprite = hoveringSprite;/*
        var foundObjects = FindObjectsOfType<ModelLoader>();
        foreach (object o in foundObjects) {
            GameObject go = (GameObject)o;
            go.GetComponent<ModelLoader>().currentlyActive = false;
            go.GetComponent<Image>().sprite = defaultSprite;

        }
        currentlyActive = true;
        GetComponent<Image>().sprite = hoveringSprite;*/
    }
}
