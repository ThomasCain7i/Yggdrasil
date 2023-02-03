using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private Vector3 moveVector;
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
    void Update()
    {
        
    }
}
