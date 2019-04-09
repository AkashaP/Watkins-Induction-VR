using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Forces this gameobject to look at a camera
 */
public class CameraAnchor : MonoBehaviour {
    private Camera cam;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(cam.transform.position, cam.transform.up);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
