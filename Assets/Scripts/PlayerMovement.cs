using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController ChrController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float Gravity = 20.0f;
    public bool canDash, isDashing;
    public float dashDistance, dashTime, dashCooldown;
    public Rigidbody rb;

    Vector3 moveDirection = Vector3.zero;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ChrController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        dashDistance = 10f;
        dashTime = 1f;
        dashCooldown = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //stop character movement in dashing
        if(isDashing)
        {
            return;
        }

        if (ChrController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

            
        }
        else
        {
            moveDirection.x = Input.GetAxis("Horizontal") * speed;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            

            float xScale = Mathf.Abs(transform.localScale.x);

            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);

            }
        }
        else
        {

        }

        moveDirection.y -= Gravity * Time.deltaTime;

        if(!isDashing) 
            ChrController.Move(moveDirection * Time.deltaTime);
       
        //Dash mechanic
        if (Input.GetKeyDown("h"))
        {
            Debug.Log("Player has dashed");
            //transform.Translate(1, 0, 0);

            //use dash
            StartCoroutine(Dash());

        }

    }

    private IEnumerator Dash()
    {
        //to turn of gravity, add variables
        canDash = false;
        isDashing = true;
        //float originalGravity = rb.gravityScale;
        // rb.gravityScale = 0f;
        rb.velocity = new Vector3(transform.localScale.x * dashDistance, 0, 0);
        //ChrController.Move(moveDirection * Time.deltaTime * dashDistance);
        yield return new WaitForSeconds(dashTime);
        Debug.Log("Dash Finished, Cooldown Starting...");
        //rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        Debug.Log("Dash cooldown complete");
        canDash = true;
    }
}