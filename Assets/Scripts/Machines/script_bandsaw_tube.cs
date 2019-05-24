using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_bandsaw_tube : MonoBehaviour {

    public GameObject listenFor;
    public float scaleThreshold = 0.9f;

    public MeshRenderer mRenderer1;
    public MeshRenderer mRenderer2;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (listenFor.transform.localScale.x < scaleThreshold)
        {
            mRenderer1.enabled = true;
            mRenderer2.enabled = true;
        } else
        {
            mRenderer1.enabled = false;
            mRenderer2.enabled = false;
        }
	}
}
