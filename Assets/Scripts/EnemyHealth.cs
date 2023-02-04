using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject hitbox;
    [SerializeField] private float enemyHP;
    private float enemyMaxHP;

    // Start is called before the first frame update
    void Start()
    {
        enemyMaxHP = 1f;
        enemyHP = enemyMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


}
