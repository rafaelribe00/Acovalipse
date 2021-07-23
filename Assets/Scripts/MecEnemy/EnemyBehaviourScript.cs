using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public float walkSpeed; 

    [HideInInspector]
    public bool mustPatrol;
    private bool mustFlip;

    public Rigidbody2D rb;
    public Transform enemyGroundCheck;
    public LayerMask groundLayer;
    
    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(enemyGroundCheck.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if(mustFlip)
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
