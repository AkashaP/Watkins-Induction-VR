using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {
    Sprite nSprite;
    void Reset()
    {
        if (nSprite == null)
            nSprite = Resources.Load("Node_Active", typeof(Sprite)) as Sprite;
        Canvas canvas = gameObject.AddComponent(typeof(Canvas)) as Canvas;
        RectTransform rt = gameObject.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(1, 1);
        Image img = gameObject.AddComponent(typeof(Image)) as Image;
        img.sprite = nSprite;
    }
}
