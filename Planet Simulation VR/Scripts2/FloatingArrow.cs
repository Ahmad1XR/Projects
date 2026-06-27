using UnityEngine;

public class FloatingArrow : MonoBehaviour
{
    public float stopDistance = 1.5f;

    [Header("Floating")]
    public float floatHeight = 0.3f;
    public float floatSpeed = 1f;

    private Transform player;
    private Vector3 startPos;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;

        startPos = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= stopDistance)
        {
            gameObject.SetActive(false);
            return;
        }

        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + new Vector3(0, newY, 0);
    }
}
