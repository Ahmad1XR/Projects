using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject blackSphere;

    public float fadeDuration = 1f;

    private bool isPaused = false;
    private bool isTransitioning = false;

    private bool yButtonLastFrame = false;

    void Start()
    {
        pauseUI.SetActive(false);
        blackSphere.SetActive(false);
    }

    void Update()
    {
        HandleVRInput();
    }

    void HandleVRInput()
    {
        InputDevice leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool pressed))
        {
            if (pressed && !yButtonLastFrame && !isTransitioning)
            {
                if (!isPaused)
                    StartCoroutine(PauseSequence());
                else
                    StartCoroutine(ResumeSequence());
            }

            yButtonLastFrame = pressed;
        }
    }

    IEnumerator PauseSequence()
    {
        isTransitioning = true;

        blackSphere.SetActive(true);
        pauseUI.SetActive(true);

        float t = 0f;

        Renderer rend = blackSphere.GetComponent<Renderer>();
        Color c = rend.material.color;

        c.a = 0f;
        rend.material.color = c;

        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;

            c.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            rend.material.color = c;

            yield return null;
        }

        Time.timeScale = 0f;
        isPaused = true;
        isTransitioning = false;
    }

    IEnumerator ResumeSequence()
    {
        isTransitioning = true;

        Time.timeScale = 1f;

        float t = 0f;

        Renderer rend = blackSphere.GetComponent<Renderer>();
        Color c = rend.material.color;

        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;

            c.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            rend.material.color = c;

            yield return null;
        }

        pauseUI.SetActive(false);
        blackSphere.SetActive(false);

        isPaused = false;
        isTransitioning = false;
    }
}