using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CapsuleManeger : MonoBehaviour
{
    public static CapsuleManeger Instance;

    public Image fadeImage;

    void Awake()
    {
        Instance = this;
    }

    public IEnumerator FadeIn(float duration)
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < duration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, time / duration);
            fadeImage.color = color;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float duration)
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < duration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, time / duration);
            fadeImage.color = color;
            yield return null;
        }
    }
}
