using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    public float currentScore;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] obstacles;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Obstacle")
        {
            gameManager.EnemyDefeated();
            Destroy(gameObject);
            //TODO connect this to a game Manager and trigger GameOver();
        }
    }
}