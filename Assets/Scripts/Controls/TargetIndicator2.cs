using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Version of TargetIndicator that places objective indicators
* Spatially, rather than as an overlay
*/
public class TargetIndicator2 : MonoBehaviour {

	public GameObject focus;
	//public GameObject indicator;
	private Camera player;

	// Use this for initialization
	void Start () {
		player = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        /*Vector3 heading = target.transform.position - player.gameObject.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        gameObject.transform.position.Set(direction.x * 1.5f, direction.y * 1.5f, direction.z * 1.5f);*/
        gameObject.transform.position = .5f * (focus.transform.position + player.transform.position);

        transform.LookAt(player.transform.position, player.transform.up);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
