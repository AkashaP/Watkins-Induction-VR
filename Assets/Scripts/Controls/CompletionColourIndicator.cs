using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * The colour of the image changes based on the completion percentage of the objective
 */
public class CompletionColourIndicator : MonoBehaviour {
    
    private Image crosshair;
    //private float completeness;
    private float h, s, v, a;

    // Use this for initialization
    void Start()
    {
        crosshair = gameObject.GetComponent<Image>();
        Color.RGBToHSV(crosshair.color, out h, out s, out v);
        s = 0;
        a = crosshair.color.a;
        h = 0.333f;
        crosshair.color = Color.HSVToRGB(h, s, v);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO if condition that only makes the colour change if the objective has a node
        float completeness = Objectives.currentTimer / Objectives.timeToCompleteObjective;
        crosshair.color = Color.HSVToRGB(h, completeness, v);
    }
}
