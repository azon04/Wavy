using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAway : MonoBehaviour
{

    void Start()
    {
        print("Fuck!");
        Fade();
    }

    public void Fade()
    {
        StartCoroutine(FadeTo(0.0f, 1.0f));
        StartCoroutine(FadeTo(1.0f, 1.0f));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        CanvasRenderer[] childrenCanvasRenderer = GetComponentsInChildren<CanvasRenderer>();
        
        float alpha = transform.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
    }
}
