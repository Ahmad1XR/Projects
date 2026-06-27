using UnityEngine;

public class PlanetButton : MonoBehaviour
{
    public string sceneName;
    public AudioSource clickSound;
    public float volume = 2.0f; 

    public void OnPress()
    {
        if (clickSound != null)
        {
            clickSound.PlayOneShot(clickSound.clip, volume);
        }

        PlanetSelector.Instance.SelectPlanet(sceneName);
    }
}
