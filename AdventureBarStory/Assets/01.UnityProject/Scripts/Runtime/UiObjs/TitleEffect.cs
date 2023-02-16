using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleEffect : MonoBehaviour
{
    public float delayTime = 0f;
    float rgb = 0;
    
    void Start()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        Invoke("Delay", delayTime);
    }

    void Delay()
    {
        StartCoroutine(ColorChange());
    }
    IEnumerator ColorChange()
    {
        while (rgb != 1)
        {
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, rgb);
            rgb += 0.1f;
        }
    }
}
