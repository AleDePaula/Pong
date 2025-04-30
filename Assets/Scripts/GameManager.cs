using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public static GameObject playerScoreText;
    public static GameObject enemyScoreText;


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


    //Functions
    private void Start()
    {
        initialBallSpeed = 10f;
        maxBallSpeed = 20f;
        playerScore = 0;
        enemyScore = 0;
        enemyCanMove = true;
        playerScoreText = GameObject.Find("PlayerScore");
        enemyScoreText = GameObject.Find("EnemyScore");      
        
    }

    public void Score(string sideScored)
    {
        if (sideScored == "LeftBorder")
        {
            enemyScore++;            
            enemyScoreText.GetComponent<TextMeshProUGUI>().text = enemyScore.ToString();
            
            
            
        }
        else if (sideScored == "RightBorder")
        {
            playerScore++;
            playerScoreText.GetComponent<TextMeshProUGUI>().text = playerScore.ToString();
            
            
        }
    }    
    
}
