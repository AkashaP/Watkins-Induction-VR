using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Version of TargetIndicator that places objective indicators
* Spatially, rather than as an overlay
*/
public class TargetIndicator2 : MonoBehaviour {

	public GameObject target;
	public GameObject indicator;
	private Camera player;

	// Use this for initialization
	void Start () {
		player = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 heading = target.position - player.gameObject.transform.position;
		Vector3 distance = heading.magnitude;
		//Vector3 direction = heading / distance;
		
	}
}
