using UnityEngine;

public class FloatingEff : MonoBehaviour
{
    public float floatHeight = 0.1f;
    public float floatSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float newValue = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        Vector3 pos = transform.localPosition;
        pos.x = startPos.x + newValue; 

        transform.localPosition = pos;
    }
}
