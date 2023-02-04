using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //ref to game manager
    //public GameManager manager;
    //health for player
    [SerializeField] private float health;
    private float maxhealth;
    private float damageFromEnemy = 1f;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 1;
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            
            //manager.GetComponent<GameManager>().RestartLevel();
            //need to switch to game manager TODO!!
            RestartLevel();
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        //check if player is colliding with an enemy

        Debug.Log("Collision with" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("EnemyHitBox"))
        {
            //Player Takes Damage on collision with enemies
            Debug.Log("Player Takes Damage");
            health -= damageFromEnemy;
            
        }
    }
    public void RestartLevel()
    {
        Debug.Log("GAMEOVER... RESTARTING LEVEL.....");
        //re-load the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
