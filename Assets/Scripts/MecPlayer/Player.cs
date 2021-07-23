using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public CharacterController2D controller;
    public HealthBarScript healthBar;
    public Animator animator;
    public GameObject deathEfect;

    float horizontalMove = 0f;
    public float runSpeed = 25f;
    bool jump = false;
    GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
            jump = true;
            animator.SetBool("isJumping", true);
        }

        PlayerDeath();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("NormEnemy"))
        {
            TakeDamage(5);
        }

        if(col.CompareTag("PowerUp"))
        {
            Heal(maxHealth-currentHealth);
            powerUp = col.gameObject;
            Destroy(powerUp);
        }

        if(col.CompareTag("Boss"))
        {
            TakeDamage(20);
        }
    }

    public void OnLanding(){
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void PlayerDeath(){
        float healthValue = healthBar.GetHealthValue();
        if(healthValue == 0f){
            Debug.Log("morreu");
            Instantiate(deathEfect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Wait();
            SceneManager.LoadScene("Morre");
        }
    }

    void Heal(int value)
    {
        currentHealth += value;
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(1);
    }
}
