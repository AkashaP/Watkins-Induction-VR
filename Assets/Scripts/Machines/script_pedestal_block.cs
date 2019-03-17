using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_pedestal_block : MonoBehaviour
{
    public bool initialState = false;
    private bool finished;

    private GameObject cutout;

    public void Awake()
    {
        cutout = transform.Find("metal dropoff").gameObject;
        finished = initialState;
        updateState();
    }

    public void setState(bool isFinished)
    {
        finished = isFinished;
        updateState();
    }

    public void updateState()
    {
        cutout.SetActive(!finished);
    }
}
