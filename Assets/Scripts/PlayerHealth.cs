using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health, maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 1;
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTakeDamage(float damageAmount)
    {
        //reduce player health my damage taken
        health -= damageAmount;

        //If health reaches 0, player dies
        if (health <= 0)
        {
            Debug.Log("Player has died");
            //add gamamanger with restart level funciton
            //gameManager.GetComponent<GameManager>().RestartLevel();
        }
    }
}
