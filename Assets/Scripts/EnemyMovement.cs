using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;


    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if (player != null) 
        { 
            enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        }
    }
}
