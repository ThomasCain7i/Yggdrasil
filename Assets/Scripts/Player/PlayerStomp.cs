using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    //ref to stomp auido source
    public AudioSource stompAudio;

    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //play stomp sound
            stompAudio.Play();
            //Destroy the enemy game object
            Destroy(collision.gameObject);
        }
    }

}
