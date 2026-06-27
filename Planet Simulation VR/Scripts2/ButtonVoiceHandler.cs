using UnityEngine;
using System.Collections;

public class ButtonVoiceHandler : MonoBehaviour
{
    public AudioSource welcomeAudio;   
    public AudioSource newVoiceAudio;  

    public float delay = 1f; 

    public void PlayNewVoice()
    {
        
        if (welcomeAudio.isPlaying)
        {
            welcomeAudio.Stop();
        }

       
        StartCoroutine(PlayAfterDelay());
    }

    IEnumerator PlayAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        if (!newVoiceAudio.isPlaying)
        {
            newVoiceAudio.Play();
        }
    }
}
