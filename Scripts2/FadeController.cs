using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public static FadeController Instance;

    public Image fadeImage;
    public float fadeDuration = 2f;

    public Color fadeColor = Color.white;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator FadeOut()
    {
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;

            fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        float t = fadeDuration;

        while (t > 0)
        {
            t -= Time.deltaTime;
            float alpha = t / fadeDuration;

            fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            yield return null;
        }
    }
}