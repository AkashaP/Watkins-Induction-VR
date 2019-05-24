using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_bandsaw_tube : MonoBehaviour {

    public GameObject listenFor;
    public float scaleThreshold = 0.9f;

    private Renderer mRenderer;

	// Use this for initialization
	void Start () {
        mRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (listenFor.transform.localScale.x < scaleThreshold)
        {
            mRenderer.enabled = true;
        } else
        {
            mRenderer.enabled = false;
        }
	}
}
