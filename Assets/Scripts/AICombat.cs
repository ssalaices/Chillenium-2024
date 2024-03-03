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
        healthBar.fillAmount = currentHealth / 100f;

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

    }

    void Die()
    {
        Debug.Log("enemy died");
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }

}
