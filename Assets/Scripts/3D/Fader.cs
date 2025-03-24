using System.Collections;
using UnityEngine;

public class Fader : Singleton<Fader>
{
    [SerializeField] CanvasGroup CG;

    public void Fade(float transitionTime)
    {
        StartCoroutine(FadeCoroutine(transitionTime));
    }

    private IEnumerator FadeCoroutine(float transitionTime)
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            CG.alpha = Mathf.Lerp(0, 1, elapsedTime / transitionTime);
            yield return null;
        }
        CG.alpha = 1;

        elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            CG.alpha = Mathf.Lerp(1, 0, elapsedTime / transitionTime);
            yield return null;
        }
        CG.alpha = 0;
    }
    public void FadeForever(float transitionTime)
    {
        StartCoroutine(FadeForeverCoroutine(transitionTime));
    }
    private IEnumerator FadeForeverCoroutine(float transitionTime)
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            CG.alpha = Mathf.Lerp(0, 1, elapsedTime / transitionTime);
            yield return null;
        }
        CG.alpha = 1;
    }
}