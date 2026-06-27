using UnityEngine;

public class CapsuleParticleTrigger : MonoBehaviour
{
    public ParticleSystem effect;

    public float increaseSpeed = 20f;
    public float maxRate = 100f;

    public AudioSource soundEffect;

    public float delayBeforeStart = 2f;

    private ParticleSystem.EmissionModule emission;

    private bool canActivate = false;
    private bool playerInside = false;
    private bool isPlaying = false;

    void Start()
    {
        emission = effect.emission;
        emission.rateOverTime = 0;
    }

    public void ActivateSequence()
    {
        canActivate = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            TryStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void TryStart()
    {
        if (canActivate && playerInside && !isPlaying)
        {
            isPlaying = true;
            StartCoroutine(StartWithDelay());
        }
    }

    System.Collections.IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        effect.Play();

        if (soundEffect != null)
        {
            soundEffect.Play();
        }

        StartCoroutine(IncreaseEffect());
    }

    System.Collections.IEnumerator IncreaseEffect()
    {
        float currentRate = 0;

        while (currentRate < maxRate)
        {
            currentRate += increaseSpeed * Time.deltaTime;
            emission.rateOverTime = currentRate;
            yield return null;
        }

        emission.rateOverTime = maxRate;
    }
}