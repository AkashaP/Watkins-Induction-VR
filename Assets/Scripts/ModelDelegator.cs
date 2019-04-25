using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The root of the GameObject where the animator of the machine is located elsewhere in the children hierarchy
 */
public class ModelDelegator : MonoBehaviour {

    /**
     * Must have animator with 'mode' integer parameter
     */
    public GameObject delegateGameObject;
    
}
