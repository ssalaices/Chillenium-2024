using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AIChase : MonoBehaviour
{

    
    public float speed;

    private float distance;
    public float distanceBetween;
    public float hitRange;

    private float timeElapsed = 3;
    public float hitCooldown;

    //Player_Combat health = player.GetComponent<Player_Combat>();
    //public Player_Control player_control;

    private GameObject player;

    Animator animator;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    { 

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float absoluteAngle = Mathf.Abs(angle);

        animator.SetFloat("Speed", 1); //always walking

        if (angle > 0) //top half of unit circle
        {
            if(angle < 45) //right animations
            {
                animator.SetFloat("XInput", 1);
                animator.SetFloat("YInput", 0);
            }
            else if (angle > 45 && angle < 135) //up animations
            {
                animator.SetFloat("XInput", 0);
                animator.SetFloat("YInput", 1);
            }
            else //left animations since angle is > 135 
            {
                animator.SetFloat("XInput", -1);
                animator.SetFloat("YInput", 0);
            }
        }

        else //bottom half of unit circle
        {
            if (absoluteAngle < 45) //right animations
            {
                animator.SetFloat("XInput", 1);
                animator.SetFloat("YInput", 0);
            }
            else if (absoluteAngle > 45 && absoluteAngle < 135) { //down animations
                animator.SetFloat("XInput", 0);
                animator.SetFloat("YInput", -1);
            }
            else //left animations since absolute angle is > 135
            {
                animator.SetFloat("XInput", -1);
                animator.SetFloat("YInput", 0);
            }
        }

        //is the timer for if the hit cooldown has passed
        timeElapsed += Time.deltaTime;

        //if the ai is in agro range
        if (distance < distanceBetween)
        {

            //if ai is in hit range and cooldown has passed
            if(distance < hitRange && timeElapsed > hitCooldown)
            {
                //player_combat.TakeDamage(20);
                //player_control.PlayFeedback(gameObject);
                timeElapsed = 0;
                animator.SetBool("Dashing", true);
                return;
            }

            animator.SetBool("Dashing", false);


            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == player.name) 
        { 
            collision.gameObject?.GetComponent<IDamagable>().TakeDamage(20);
        }
    }
}


