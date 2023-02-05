using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    //Variables

    private Vector3 moveDirection;
    private Vector3 lastMove;
    private float speed = 5;
    private float jumpForce = 8;
    private float gravity = 25;
    private float verticalVelocity;
    private CharacterController  controller;
    public Animator animator;
    //bool to check player is on ground
    public bool playerIsGrounded;
    //Audio
    AudioSource Audiosource;

    // Start is called before the first frame update
    void Start()
    {
        //Charcter Controller
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    private void Update()
    {
        //Get movement on the horizontal axis
        moveDirection = Vector3.zero;
        moveDirection.x = (Input.GetAxis("Horizontal"));

        //If the character is on the ground
        if(controller.isGrounded)
        {
            //set player to grounded
            playerIsGrounded = true;

            verticalVelocity = -1;

            if(Input.GetButton("Jump"))
            {
                playerIsGrounded = false;
                //Jump animation on
                animator.SetBool("isJumping", true);
                //Turn vertical velocity into jumpForce to jump
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            //If not grounded - verticalVolcity == gravity
            verticalVelocity -= gravity * Time.deltaTime;

            //Cannot alter character if jumping
            moveDirection = lastMove;
        }

        moveDirection.y = 0;
        moveDirection.Normalize();
        moveDirection *= speed;
        moveDirection.y = verticalVelocity;

        controller.Move(moveDirection * Time.deltaTime);
        lastMove = moveDirection;


        if(controller.isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        //Turning the character
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isRunning", true);

            float xScale = Mathf.Abs(transform.localScale.x);

            if (Input.GetAxis("Horizontal") < 0)
            {
                //If horizontal is > 0 turn the character to the right
                transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
            }

            else
            {
                //If horizontal is < 0 turn the character to the left
                transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);

            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnControllerColliderHit (ControllerColliderHit hit)
    {
        //If not on the ground and raycast > 0.1 then allow jump
        if(!controller.isGrounded && hit.normal.y < 0.5f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //Draw raycast to show when wall jump is avaliable
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                verticalVelocity = jumpForce;
                moveDirection = hit.normal * speed;
            }
        }
    }
}
