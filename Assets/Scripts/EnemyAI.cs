using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //ref to player character
    public GameObject player;
    //ref to patrol points
    public GameObject pointA, pointB;
    //how much damage enemy does to player
    public float enemyDamage = 1;
    public float playerDistance = 3f;
    //how close the enemy will go to patrol point before switching points
    public float patrolDistanceAB = 0.1f;
    //distance when enemy will use patrol points
    public float patrolPointInRange = 10f;
    public float enemySpeed = 1f;
    //check which way enemy is facing
    public enum EnemyFacing { f, b }
    public EnemyFacing enemyDirection;
    //enemy states
    public enum EnemyAiSM { idle, chasing, patrolA, patrolB }
    public EnemyAiSM enemyAiSM;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //On game run, look for instiated player actor
        player = GameObject.FindGameObjectWithTag("Player");
        pointA = GameObject.FindGameObjectWithTag("PatrolPointA");
        pointB = GameObject.FindGameObjectWithTag("PatrolPointB");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Distance checker, to chase player
        Debug.Log("Enemy is " + Vector3.Distance(player.transform.position, transform.position) + "from player");


        switch (enemyAiSM)
        {
            //default state idle
            case EnemyAiSM.idle:
                //enemy check if they are close to a patrol point, to start patroling
            if (Vector3.Distance(pointA.transform.position, transform.position) < patrolPointInRange)
                {
                    //switch to parol a case
                    enemyAiSM = EnemyAiSM.patrolA;
                }
            if (Vector3.Distance(player.transform.position, transform.position) < playerDistance)
                {
                    //switch to chasing case
                    enemyAiSM = EnemyAiSM.chasing;
                }
                break;

            case EnemyAiSM.patrolA:

                //look at and go to point a
                transform.LookAt(pointA.transform.position);
                transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);

                //once enemy has reached point a, switch to point b
                if (Vector3.Distance(pointA.transform.position, transform.position) < patrolDistanceAB)
                {
                    //switch to parol a case
                    enemyAiSM = EnemyAiSM.patrolB;
                }

                //if enemy sees player, chase player
                if (Vector3.Distance(player.transform.position, transform.position) < playerDistance)
                {
                    //switch to chasing case
                    enemyAiSM = EnemyAiSM.chasing;
                }

                break;

            case EnemyAiSM.patrolB:

                //look at and go to point b
                transform.LookAt(pointB.transform.position);
                transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);

                //once enemy has reached point b, switch to point a
                //once enemy has reached point a, switch to point b
                if (Vector3.Distance(pointB.transform.position, transform.position) < patrolDistanceAB)
                {
                    //switch to parol a case
                    enemyAiSM = EnemyAiSM.patrolA;
                }

                //if enemy sees player, chase player
                if (Vector3.Distance(player.transform.position, transform.position) < playerDistance)
                {
                    //switch to chasing case
                    enemyAiSM = EnemyAiSM.chasing;
                }
                break;

            case EnemyAiSM.chasing:

                //look at and follow player
                //Debug.Log("Chase player");
                transform.LookAt(player.transform.position);
                transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);

                if (Vector3.Distance(player.transform.position, transform.position) > playerDistance)
                {
                    enemyAiSM = EnemyAiSM.idle;
                }
                break;

            default:
                Debug.Log("Enemy State is" + enemyAiSM);
                break;

        }

        
            

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(enemyDamage);
        }
    }
}
