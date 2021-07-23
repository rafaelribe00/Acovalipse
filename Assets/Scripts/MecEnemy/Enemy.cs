using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEfect; 

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0){
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEfect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Boss").GetComponent<BossFire>().UpdateHealth();
    }
}
