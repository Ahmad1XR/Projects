using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FadeAndTeleport : MonoBehaviour
{
    public Image fadeImage;
    public float waitBeforeFade = 5f;
    public float fadeDuration = 2f;
    public string sceneName;

    public void StartSequence()
    {
        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        yield return new WaitForSeconds(waitBeforeFade);

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = time / fadeDuration;
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        fadeImage.color = new Color(1, 1, 1, 1);

        SceneManager.LoadScene(sceneName);
    }
}
