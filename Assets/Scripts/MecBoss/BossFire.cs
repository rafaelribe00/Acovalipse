using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFire : MonoBehaviour
{
    public Transform firePointBoss;
    public GameObject bulletPrefab;
    GameObject[] enemyNumber;

    public int health = 600;
    int currentHealth;
    public GameObject deathEfect;
    public BossHealthBar healthBar;

    private GameObject bulletInGame;

    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    public void Shoot(Vector2 target)
    {
        bulletInGame = Instantiate(bulletPrefab, firePointBoss.position, firePointBoss.rotation);
        bulletInGame.GetComponent<BulletScript>().Go(target);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            Die();
        }
    }

    public void UpdateHealth()
    {
        currentHealth -= 30;
        /*enemyNumber = GameObject.FindGameObjectsWithTag("NormEnemy");
        health -= (health/2)*(enemyNumber.Length/10);*/
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        Instantiate(deathEfect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene("Ganha");
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Vector2 target = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
            Shoot(target);
        }
    }*/
}