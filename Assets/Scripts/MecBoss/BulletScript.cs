using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    
    public void Go(Vector2 target)
    {
        Debug.Log(target);
        rb.velocity = target * speed;
    }
}
