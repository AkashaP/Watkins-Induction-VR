using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Rotates when looked at
 */
public class Rotator : MonoBehaviour {
    public static float lookAtThreshold = 1f;

    public Camera cam;// = Camera.main;
    public GameObject target;
    public Vector3 rotation;

    // Use this for initialization
    void Start () {
        //cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 lookAt = cam.WorldToViewportPoint(gameObject.transform.position);
        if (lookAt.x <= lookAtThreshold && lookAt.y <= lookAtThreshold)
        {
            target.transform.Rotate(rotation);
        }
	}
}
