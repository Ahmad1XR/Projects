using UnityEngine;

public class CatWalking : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 2f; 

    private Transform target;
    private Animator anim;

    void Start()
    {
        target = pointB; 
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;

           
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
