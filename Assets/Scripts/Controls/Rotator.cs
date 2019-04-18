using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Rotates when looked at
 */
public class Rotator : MonoBehaviour {
    public static float lookAtThreshold = .05f;

    public Camera cam;// = Camera.main;
    //public GameObject target;
    public Vector3 rotation;
    public OnlyOneActive root;

    // Use this for initialization
    void Start () {
        //cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 lookAt = cam.WorldToViewportPoint(gameObject.transform.position);
        if (lookAt.x >= 0.5f - lookAtThreshold &&
            lookAt.x <= 0.5f + lookAtThreshold &&
            lookAt.y >= 0.5f - lookAtThreshold &&
            lookAt.y <= 0.5f + lookAtThreshold)
        {
            root.activeChild.transform.Rotate(rotation);
            CompletionColourIndicator.completeness = .5f;
        }
	}
}
