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
    public float enemyDamage;
    public float playerDistance = 5f;
    public float patrolDistanceAB = 3f;
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

        //if distance is less than... chase player
        if (Vector3.Distance(player.transform.position, transform.position) < playerDistance)
        {
            //chase player
            Debug.Log("Chase player");
            transform.LookAt(player.transform.position);
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        }
        else
        {
            //patrol
        }

        switch (enemyAiSM)
        {
            //default state idle
            case EnemyAiSM.idle:
                //enemy check if they are close to a patrol point
            if (Vector3.Distance(pointA.transform.position, transform.position) < patrolDistanceAB)
                {
                    //go to point a
                }
            if (Vector3.Distance(player.transform.position, transform.position) < playerDistance)
                {
                    //chase player
                }
                break;

            case EnemyAiSM.patrolA:

                //look at and go to point a

                //once enemy has reached point a, switch to point b

                //if enemy sees player, chase player

                break;

            case EnemyAiSM.patrolB:

                //look at and go to point b

                //once enemy has reached point b, switch to point a

                //if enemy sees player, chase player

                break;

            case EnemyAiSM.chasing:

                //look at and follow player
                break;

            default:
                break;

        }
            

    }
}
