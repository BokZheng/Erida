using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFadeIn : MonoBehaviour
{
    public CanvasGroup canvasgroup4button;
    public float fadingduration = 1.0f;
    void Start()
    {
       canvasgroup4button.alpha = 0f;
    }

    public void StartFadingIn()
    {
        StartCoroutine(FadeInButton());
    }

    IEnumerator FadeInButton()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadingduration)
        {
            elapsedTime += Time.deltaTime;
            canvasgroup4button.alpha = Mathf.Clamp01(elapsedTime / fadingduration);
            yield return null;
        }
    }
   
}
