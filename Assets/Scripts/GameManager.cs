using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    //References:    
    public static GameObject UI;
    public static TextMeshProUGUI playerScoreText;
    public static TextMeshProUGUI enemyScoreText;


    // Score variables
    public int playerScore;
    public int enemyScore;


    //Dificulty variables
    public float initialBallSpeed;   
    public float maxBallSpeed;
    public float enemyReactionTime;
    public float enemyPaddleSpeed;


    //Ball variables 
    public Vector2 ballPosition;
    

    //Enemy Paddle variables
    public bool enemyCanMove;

    // Sound variables
    public AudioSource paddleSound;
    public AudioSource wallSound;
    public AudioSource scoreSound;
    public AudioSource gameOverSound;

    //Functions
    private void Start()
    {
        initialBallSpeed = 10f;
        maxBallSpeed = 20f;
        playerScore = 0;
        enemyScore = 0;
        enemyCanMove = true;
        playerScoreText = GameObject.Find("PlayerScore").GetComponent<TextMeshProUGUI>();
        enemyScoreText = GameObject.Find("EnemyScore").GetComponent<TextMeshProUGUI>(); 

        paddleSound = GameObject.Find("PaddleSound").GetComponent<AudioSource>();
        wallSound = GameObject.Find("WallSound").GetComponent<AudioSource>();
        scoreSound = GameObject.Find("ScoreSound").GetComponent<AudioSource>();
        gameOverSound = GameObject.Find("GameOverSound").GetComponent<AudioSource>();     
        
    }

    public void Score(string sideScored)
    {
        if (sideScored == "LeftBorder")
        {
            enemyScore++;            
            enemyScoreText.text = enemyScore.ToString();
            
            
            
        }
        else if (sideScored == "RightBorder")
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
            
            
        }
    }

    //Sound manager

    public void PlayPaddleSound()
    {
        paddleSound.Play();
        
    }
    public void PlayWallSound()
    {
        wallSound.Play();
    }
    public void PlayScoreSound()
    {
        scoreSound.Play();
    }
    public void PlayGameOverSound()
    {
        gameOverSound.Play();
    }
    
}
