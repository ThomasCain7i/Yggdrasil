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
    [SerializeField] private float enemySpeed = 1f;
    //check which way enemy is facing
    public enum EnemyFacing { f, b }
    public EnemyFacing enemyDirection;
    //enemy states
    public enum EnemyAiSM { idle, chasing }
    public EnemyAiSM enemyAiSM;

    // Start is called before the first frame update
    void Start()
    {
        //On game run, look for instiated player actor
        player = GameObject.FindGameObjectWithTag("Player");
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


    }
}
