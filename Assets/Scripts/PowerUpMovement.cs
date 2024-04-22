using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody powerRb;
    private GameObject player;


    private void Awake()
    {
        powerRb = GetComponent<Rigidbody>();
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
            powerRb.AddForce((-player.transform.position + transform.position).normalized * speed);
        }
    }
}
