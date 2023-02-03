using System.Collections;
using System.Collections;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    private Vector3 lastMove;
    private float speed = 8;
    private float jumpForce = 8;
    private float gravity = 25;
    private float verticalVelocity;
    private CharacterController  Controller;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    private void Update()
    {
        moveDirection = Vector3.zero;
        moveDirection.x = (Input.GetAxis("Horizontal"));

        if(Controller.isGrounded)
                {
            verticalVelocity = -1;

            if(Input.GetButton("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            moveDirection = lastMove;
        }

        moveDirection.y = 0;
        moveDirection.Normalize();
        moveDirection *= speed;
        moveDirection.y = verticalVelocity;

        Controller.Move(moveDirection * Time.deltaTime);
        lastMove = moveDirection;

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

    }
}
