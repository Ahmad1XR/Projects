using UnityEngine;

public class PlanetGravity : MonoBehaviour
{    public enum PlanetType
    {
        Earth,
        Mars,
        Venus,
        Neptune,
        Saturn
    }

    public PlanetType currentPlanet;
    private Rigidbody rb;
    private float gravityValue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetGravity();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * gravityValue, ForceMode.Acceleration);
    }

    void SetGravity()
    {
        switch (currentPlanet)
        {
            case PlanetType.Earth:
                gravityValue = 9.81f;
                break;

            case PlanetType.Mars:
                gravityValue = 3.7f;
                break;

            case PlanetType.Venus:
                gravityValue = 8.87f;
                break;

            case PlanetType.Neptune:
                gravityValue = 11.15f;
                break;

            case PlanetType.Saturn:
                gravityValue = 10.44f;
                break;
        }
    }
}
