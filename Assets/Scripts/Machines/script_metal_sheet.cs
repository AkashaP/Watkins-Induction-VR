using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_metal_sheet : MonoBehaviour
{
    public bool initialState = false;
    private bool finished;

    private GameObject cutout;

    public void Awake()
    {
        cutout = transform.Find("metal_sheet_dropoff").gameObject;
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
