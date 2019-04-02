using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyOneActive : MonoBehaviour {

    public GameObject activeChild;

    public void SetOneActive(GameObject active)
    {
        DeactivateAll();
        active.SetActive(true);
        activeChild = active;
    }

    public void DeactivateAll()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
