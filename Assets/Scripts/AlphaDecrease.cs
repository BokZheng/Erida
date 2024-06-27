using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaDecrease : MonoBehaviour
{
    public float duration = 2.0f; 
    private SpriteRenderer spriteRenderer;
    private Coroutine currentCoroutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on " + gameObject.name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(ChangeAlphaOverTime(0f));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(ChangeAlphaOverTime(1f));
        }
    }

    IEnumerator ChangeAlphaOverTime(float targetAlpha)
    {
        float elapsedTime = 0.0f;
        Color color = spriteRenderer.color;
        float startAlpha = color.a;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            spriteRenderer.color = color;
            yield return null; 
        }

        color.a = targetAlpha;
        spriteRenderer.color = color;
    }
}