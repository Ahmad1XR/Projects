using UnityEngine;
using System.Collections;
using System;
public class CapsuleTeleport : MonoBehaviour
{
    public float waitTime = 4f;
    public static event Action OnTeleportStart;

    private bool playerInside = false;
    private bool isWaiting = false;

    private Coroutine teleportCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            if (!isWaiting)
            {
                teleportCoroutine = StartCoroutine(WaitAndTeleport());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            if (teleportCoroutine != null)
            {
                StopCoroutine(teleportCoroutine);
                teleportCoroutine = null;
            }

            isWaiting = false;
        }
    }

    IEnumerator WaitAndTeleport()
    {
        isWaiting = true;

        yield return new WaitForSeconds(waitTime);

        if (!playerInside)
        {
            isWaiting = false;
            teleportCoroutine = null;
            yield break;
        }

        OnTeleportStart?.Invoke();

        yield return FadeController.Instance.FadeOut();

        if (playerInside)
        {
            string sceneName = PlanetSelector.Instance.selectedSceneName;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        isWaiting = false;
        teleportCoroutine = null;
    }
}