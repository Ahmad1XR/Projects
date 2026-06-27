using System.Collections;
using UnityEngine;

public class SoundWithDelay : MonoBehaviour
{
    public AudioSource audioSource;

    public float delay = 5f;

    void Start()
    {
        StartCoroutine(PlaySoundAfterDelay());
    }

    IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}

