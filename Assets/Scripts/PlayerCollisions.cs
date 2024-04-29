using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject[] obstacles;
    GameManager gameManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            gameManager.GameOver();
        }
        if (other.transform.tag == "Enemy")
        {
            gameObject.SetActive(false);
            gameManager.GameOver();
        }
    }
}