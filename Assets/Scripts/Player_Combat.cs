using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_Combat : MonoBehaviour, IDamagable
{

    Animator animator;
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    public float currentHealth = 100f;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = currentHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        //if dead run the die function
        if(currentHealth <= 0) {
            Die();
        }
    }

    void Attack()
    {
        //play attack
        //detect enemies in range
        //damage them
        animator.SetBool("Dashing", true);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<AICombat>().TakeDamage(attackDamage);
        }

    }


    //supposed to draw the hitbox for enemies
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;
    }

    void Die()
    {
        Debug.Log("You died");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //add some game over screen stuff

        SceneManager.LoadSceneAsync(2);
    }

}
