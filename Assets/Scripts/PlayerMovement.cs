using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController ChrController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float Gravity = 20.0f;

    Vector3 moveDirection = Vector3.zero;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ChrController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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

        ChrController.Move(moveDirection * Time.deltaTime);
    }
}