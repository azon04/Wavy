//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class FadeAway : MonoBehaviour
//{
//    void Start()
//    {
//        Component[] comps = gameObject.GetComponentsInChildren<Component>();

//        foreach (Component c in comps)
//        {
//            if (c is Graphic)
//            {
//                (c as Graphic).CrossFadeAlpha(0, 1, true);
//            }


//            //StartCoroutine(Fade(1f, 2f));
//            //StartCoroutine(Fade(0f, 1f));
//        }
//    }

//        //void Update()
//        //{
//        //}

//        /*IEnumerator Fade(float aValue, float aTime)
//    {

//        float alpha = GetComponent<CanvasRenderer>().GetAlpha();

//        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
//        {
//            print(alpha);
//            GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(alpha, aValue, t));
//            yield return null;
//        }
//    }*/
//}
