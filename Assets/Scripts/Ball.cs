using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;    
    private Vector2 ballDirection;
    private float ballSpeed;
    private Vector2 ballInitialPosition;
    private GameManager gameManager;    

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ballSpeed = gameManager.initialBallSpeed;        
        ResetBall();     
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="LeftBorder" || collision.gameObject.name=="RightBorder")
        {
            gameManager.Score(collision.gameObject.name);
            gameManager.PlayScoreSound();
            ResetBall();
        }
        else if(collision.gameObject.name=="TopBorder" || collision.gameObject.name=="BottomBorder")
        {
            ballDirection.y = -1*ballDirection.y;
            gameManager.PlayWallSound();
            
        }
        else if(collision.gameObject.name=="PlayerPaddle" || collision.gameObject.name=="EnemyPaddle")        {
            
            ballDirection.x = -1*ballDirection.x;
            ballSpeed += 0.5f;
            gameManager.PlayPaddleSound();
            if(ballSpeed > gameManager.maxBallSpeed)
            {
                ballSpeed = gameManager.maxBallSpeed;
            }
        }
        

    }
    private void ResetBall()
    {
        this.transform.position = ballInitialPosition;
        ballSpeed = gameManager.initialBallSpeed;
        
        ballDirection = GetBallDirection();
       
        rb.linearVelocity = ballDirection * ballSpeed;

        gameManager.enemyCanMove = true;
    }

    void Update()
    {
       rb.linearVelocity = ballDirection * ballSpeed;       
       
    }

    void FixedUpdate()
    {
        gameManager.ballPosition = rb.position;
    }

    private Vector2 GetBallDirection()
    {
        bool right = Random.value < 0.5f;
        float angle;

        if (right){
            if(Random.value > 0.5f)
                angle = Random.Range(30f, 60f);
            else
                angle = Random.Range(290f, 320f);
        }
        else
        {
            if(Random.value > 0.5f)
                angle = Random.Range(120f, 150f);
            else
                angle = Random.Range(210f, 240f);
            
        }
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }




}
