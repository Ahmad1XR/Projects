using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform Target; 
    private Rigidbody rb;

    public XRDirectInteractor handInteractor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 50f;
    }

    void FixedUpdate()
    {
        if (Target == null || handInteractor == null) return;

        if (handInteractor.hasSelection)
        {
            rb.isKinematic = true;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            return;
        }
        else
        {
            rb.isKinematic = false;
        }

        Vector3 velocity = (Target.position - transform.position) / Time.fixedDeltaTime;
        rb.linearVelocity = Vector3.ClampMagnitude(velocity, 20f);

        Quaternion rotationDifference = Target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angle, out Vector3 axis);

        if (angle > 180f)
            angle -= 360f;

        Vector3 angularVelocity = axis * angle * Mathf.Deg2Rad / Time.fixedDeltaTime;
        rb.angularVelocity = Vector3.ClampMagnitude(angularVelocity, 25f);
    }
}