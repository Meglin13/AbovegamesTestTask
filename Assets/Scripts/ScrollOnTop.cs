using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollOnTop : MonoBehaviour
{
    void Start()
    {
        ScrollRect scrollRect = GetComponent<ScrollRect>();
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }
}
