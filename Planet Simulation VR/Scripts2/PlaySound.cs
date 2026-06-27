using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public Light phoneLight;
    public float delay = 5f;

    public float startIntensity = 0.05f; 
    public float maxIntensity = 2f;      
    public float fadeDuration = 2f;     

    void Start()
    {
        phoneLight.enabled = false;
        phoneLight.intensity = startIntensity;

        StartCoroutine(StartEffect());
    }

    IEnumerator StartEffect()
    {
        yield return new WaitForSeconds(delay);

        audioSource.Play();

        phoneLight.enabled = true;

        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;

            phoneLight.intensity = Mathf.Lerp(startIntensity, maxIntensity, t / fadeDuration);

            yield return null;
        }

        phoneLight.intensity = maxIntensity;
    }
}
