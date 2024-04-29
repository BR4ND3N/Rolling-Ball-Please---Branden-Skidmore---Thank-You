using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance == null) Instance = this;
    }


    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    [SerializeField] private UIManager uiManager;

    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }


    public void GameOver()
    {
        currentScore = 0f;
        isPlaying = false;
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            currentScore += Time.deltaTime;
        }



    }

    public void EnemyDefeated()
    {
        currentScore += 20;
    }

    public void StartGame()
    {
        isPlaying = true;

        uiManager.playButton.gameObject.SetActive(false);
    }
}
