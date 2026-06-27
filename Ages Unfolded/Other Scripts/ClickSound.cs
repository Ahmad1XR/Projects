using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class ClickSound : MonoBehaviour
{
    public AudioSource clickSound;
    
    public void PlayThisSoundEffect()
    {
        if (clickSound != null)
            clickSound.Play();
        else
            Debug.LogWarning("AudioSource not assigned!");
    }
    void Start()
    {
        if (clickSound != null)
            clickSound.Play();
    }
}
