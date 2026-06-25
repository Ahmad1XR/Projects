using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
public class PhoneGrabInteractable : MonoBehaviour
{
    public FadeAndTeleport fadeScript;
    private XRGrabInteractable grab;
    private bool started = false;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (started) return;
        started = true;

        fadeScript.StartSequence();
    }
}
