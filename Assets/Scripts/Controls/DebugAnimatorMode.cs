using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAnimatorMode : MonoBehaviour {

    public OnlyOneActive ooa;

    private Animator activeAnimator;

	// Update is called once per frame
	void Update () {
        // Resolve animator
        activeAnimator = ooa.activeChild.GetComponent<Animator>();
        if (activeAnimator == null)
        {
            ModelDelegator modelDelegator = ooa.activeChild.GetComponent<ModelDelegator>();
            if (modelDelegator == null) return;
            activeAnimator = modelDelegator.delegateGameObject.GetComponent<Animator>();
        }
        if (activeAnimator == null)
            return;

        // Control animator mode with [ and ]
        int currentMode = activeAnimator.GetInteger("mode");
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            if (currentMode > 0)
            {
                activeAnimator.SetInteger("mode", currentMode - 1);
                Debug.Log("Animator mode set to " + (currentMode - 1));
            }
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            activeAnimator.SetInteger("mode", currentMode+1);
            Debug.Log("Animator mode set to " + (currentMode+1));
        }
    }
}
