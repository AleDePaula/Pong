using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public int playerScore;
    public int enemyScore;
    public float initialBallSpeed;   
    public float maxBallSpeed;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        initialBallSpeed = 10f;
        maxBallSpeed = 20f;
        playerScore = 0;
        enemyScore = 0;
    }

    public void Score(String sideScored)
    {
        if (sideScored == "LeftBorder")
        {
            enemyScore++;
            print(enemyScore);
        }
        else if (sideScored == "RightBorder")
        {
            playerScore++;
            print(playerScore);
        }
    }    
    
}
