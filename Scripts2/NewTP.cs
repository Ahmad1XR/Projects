using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewTP : MonoBehaviour
{
    [Header("References")]
    public ParticleSystem effect;
    public AudioSource audioSource;
    public Image fadeImage;

    [Header("Particle Settings")]
    public float increaseSpeed = 20f;
    public float maxRate = 100f;

    [Header("General Settings")]
    public string sceneName;
    public float startDelay = 2f;
    public float fadeDuration = 2f;

    private bool triggered = false;
    private ParticleSystem.EmissionModule emission;

    void Start()
    {
        if (effect != null)
        {
            emission = effect.emission;
            emission.rateOverTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(Sequence());
        }
    }

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(startDelay);

        if (effect != null)
        {
            effect.Play();
            StartCoroutine(IncreaseParticle());
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }

        yield return new WaitForSeconds(1.5f);

        yield return StartCoroutine(FadeOut());

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator IncreaseParticle()
    {
        float currentRate = 0f;

        while (currentRate < maxRate)
        {
            currentRate += increaseSpeed * Time.deltaTime;
            emission.rateOverTime = currentRate;

            yield return null;
        }

        emission.rateOverTime = maxRate;
    }

    IEnumerator FadeOut()
    {
        float t = 0f;

        Color c = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;

            fadeImage.color = new Color(c.r, c.g, c.b, alpha);

            yield return null;
        }
    }
}