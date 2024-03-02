using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    
    public float walkSpeed;
    public float runSpeed;
    private float movSpeed = 5;
    float speedX, speedY;
    Rigidbody2D rb;
    Animator animator;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 2f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = .1f;

    [SerializeField] private TrailRenderer tr;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing)
        {
            animator.SetBool("Dashing", true);
            return;
        } 
        else {
            animator.SetBool("Dashing", false);
        }

        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;

        if (speedX != 0) speedY = 0;


        Vector2 velocityVector = new Vector2(speedX, speedY);
        rb.velocity = velocityVector;
        
        //this is for dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
        }

        //pass animation values ONLY WHEN MOVING
        //so I can also have idle animations in a direction
        if (velocityVector.magnitude != 0)
        {
            animator.SetFloat("Speed", 1);
            animator.SetFloat("XInput", speedX);
            animator.SetFloat("YInput", speedY);
        } 
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(speedX * dashingPower, speedY * dashingPower);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
