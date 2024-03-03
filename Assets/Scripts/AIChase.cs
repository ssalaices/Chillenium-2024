using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChase : MonoBehaviour
{

    public GameObject player;
    public float speed;

    private float distance;
    public float distanceBetween;
    public float hitRange;

    private float timeElapsed = 3;
    public float hitCooldown;

    //Player_Combat health = player.GetComponent<Player_Combat>();
    public Player_Combat player_combat;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    { 


        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //is the timer for if the hit cooldown has passed
        timeElapsed += Time.deltaTime;


        //if the ai is in agro range
        if (distance < distanceBetween)
        {

            //if ai is in hit range and cooldown has passed
            if(distance < hitRange && timeElapsed > hitCooldown)
            {
                player_combat.currHealth -= 20;

                timeElapsed = 0;

                return;
            }

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }


    }
}
