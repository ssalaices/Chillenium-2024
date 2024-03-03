using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        Debug.Log("enemy died");

        animator.SetBool("IsDead", true);
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
