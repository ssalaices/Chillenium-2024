using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AICombat : MonoBehaviour
{

    public int maxHealth = 100;
    SpriteRenderer spriteRenderer;
    public Animator animator;

    //health bar stuff
    public Image healthBar;
    public float currentHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for health bar
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }
    }


    void Die()
    {
        Debug.Log("enemy died");

        animator.SetBool("IsDead", true);
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    //health bar stuff
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(float healingAmount)
    {
        currentHealth += healingAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);

        healthBar.fillAmount = currentHealth / 100f;
    }

}
