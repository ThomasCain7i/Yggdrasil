using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash, isDashing;
    public float dashDistance, dashTime, dashCooldown;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashDistance = 10f;
        dashTime = 1f;
        dashCooldown = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        

        Vector3 inputFromPlayer = new Vector3(horizontalInput, 0, 0);
        //Dash mechanic
        if (Input.GetKeyDown("h"))
        {
            Debug.Log("Player has dashed");
            //transform.Translate(1, 0, 0);

            //use dash
            StartCoroutine(Dash2());

        }
    }

    private IEnumerator Dash2()
    {
        //to turn of gravity, add variables
        canDash = false;
        isDashing = true;
        //float originalGravity = rb.gravityScale;
        // rb.gravityScale = 0f;
        rb.velocity = new Vector3(transform.localScale.x * dashDistance, 0, 0);
        yield return new WaitForSeconds(dashTime);
        Debug.Log("Dash Finished, Cooldown Starting...");
        //rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        Debug.Log("Dash cooldown complete");
        canDash = true;
    }
}
