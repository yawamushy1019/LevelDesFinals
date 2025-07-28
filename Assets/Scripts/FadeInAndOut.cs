using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAndOut : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    public bool fadein = false;
    public bool fadeout = false;

    public float TimeToFade = 1f;

    void Start()
    {
        // Start fully invisible
        canvasgroup.alpha = 0f;
        canvasgroup.interactable = false;
        canvasgroup.blocksRaycasts = false;
    }

    void Update()
    {
        if (fadein)
        {
            if (canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += TimeToFade * Time.deltaTime;

                if (canvasgroup.alpha >= 1f)
                {
                    canvasgroup.alpha = 1f;
                    fadein = false;

                    // Enable interaction
                    canvasgroup.interactable = true;
                    canvasgroup.blocksRaycasts = true;
                }
            }
        }

        if (fadeout)
        {
            if (canvasgroup.alpha > 0)
            {
                canvasgroup.alpha -= TimeToFade * Time.deltaTime;

                if (canvasgroup.alpha <= 0f)
                {
                    canvasgroup.alpha = 0f;
                    fadeout = false;

                    // Disable interaction
                    canvasgroup.interactable = false;
                    canvasgroup.blocksRaycasts = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadein = true;
        // Ensure alpha starts at 0 when beginning fade in
        if (canvasgroup.alpha == 0f)
        {
            canvasgroup.interactable = false;
            canvasgroup.blocksRaycasts = false;
        }
    }

    public void FadeOut()
    {
        fadeout = true;
    }

    public IEnumerator FadeInCanvas()
    {
        canvasgroup.blocksRaycasts = true;
        canvasgroup.interactable = true;

        while (canvasgroup.alpha < 1f)
        {
            canvasgroup.alpha += TimeToFade * Time.deltaTime;
            yield return null;
        }

        canvasgroup.alpha = 1f;
    }

    public IEnumerator FadeOutCanvas()
    {
        while (canvasgroup.alpha > 0f)
        {
            canvasgroup.alpha -= TimeToFade * Time.deltaTime;
            yield return null;
        }

        canvasgroup.alpha = 0f;
        canvasgroup.blocksRaycasts = false;
        canvasgroup.interactable = false;
    }
}
