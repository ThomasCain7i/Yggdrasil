using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashs : MonoBehaviour
{
    CharacterController Chrcontroller;

    public float dashSpeeds = 0.5f;
    public float dashTimes = 0.25f;
    public float dashCD = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Chrcontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        dashCD -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (dashCD <= 0)
            {
                StartCoroutine(Dashes());
            }
        }
    }

    IEnumerator Dashes()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTimes)
        {
            transform.Translate(Vector3.right * dashSpeeds);
            dashCD = 3;
            yield return null;
        }
    }
}
