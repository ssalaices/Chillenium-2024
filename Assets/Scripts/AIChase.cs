using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AIChase : MonoBehaviour
{

    public GameObject player;
    public float speed;

    private float distance;
    public float distanceBetween;
    public float hitRange;

    private float timeElapsed = 0f;

    Animator animator;

    private void Start()
    {
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

        //if the ai is in agro range
        if (distance < distanceBetween)
        {
            timeElapsed += Time.deltaTime;
            //if ai is in hit range
            if (distance < hitRange && timeElapsed > 1000)
            {
                Debug.Log("You've been hit!");
                return;
            }

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
