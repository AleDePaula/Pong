using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    public static GameManager instance;


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
        
    }

    public void Score(string sideScored)
    {
        if (sideScored == "LeftBorder")
        {
            enemyScore++;
            
        }
        else if (sideScored == "RightBorder")
        {
            playerScore++;
            
        }
    }    
    
}
