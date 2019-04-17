using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Version of TargetIndicator that places objective indicators
* Spatially, rather than as an overlay.
* This exists because overlay GUI is unsupported in VR. 
* 
* Attach this script to a world space canvas object, with an indicator image referenced to the indicator variable
*/
public class TargetIndicator2 : MonoBehaviour {

	public GameObject focus;
	public GameObject indicator;
	private Camera player;

	// Use this for initialization
	void Start () {
		player = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        if (focus == null)
        {
            indicator.SetActive(false);
            return;
        }
        indicator.SetActive(true);

        gameObject.transform.position = .5f * (focus.transform.position + player.transform.position);

        transform.LookAt(player.transform.position, player.transform.up);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
