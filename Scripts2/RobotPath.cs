using UnityEngine;

public class RobotPath : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;

    public float startDelay = 4f; 

    private int currentPoint = 0;
    private float timer = 0f;
    private bool started = false;

    void Update()
    {
        
        if (!started)
        {
            timer += Time.deltaTime;

            if (timer >= startDelay)
            {
                started = true;
            }
            else
            {
                return; 
            }
        }

        if (points.Length == 0) return;

        Transform target = points[currentPoint];

       
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                enabled = false;
            }
        }
    }
}