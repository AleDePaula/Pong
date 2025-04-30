using UnityEngine;

public class EnemyPaddleAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gameManager;
    private float paddleSpeed;
    private Vector2 ballPosition;
       

    private void Start()
    {        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();        
        rb = GetComponent<Rigidbody2D>();
        ballPosition = gameManager.ballPosition;
        paddleSpeed = 10f;        
    }
    private void FixedUpdate()
    {
        ballPosition = gameManager.ballPosition;
        MovePaddle();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
    
        if (collision.gameObject.name == "Ball")
        {
            gameManager.enemyCanMove = false;
            print(gameManager.enemyCanMove);
        }
    
    }
    private void MovePaddle()
    {
        float moveDirection = 0f;

        if (gameManager.enemyCanMove)
        {
            if (ballPosition.y > rb.position.y)
            {
                moveDirection = 1f;
            }
            else if (ballPosition.y < rb.position.y)
            {
                moveDirection = -1f;
            }
            else if (ballPosition.y == rb.position.y)
            {
                moveDirection = 0f;
            }

            rb.linearVelocityY = moveDirection * paddleSpeed;
        }
        else
        {
            if (rb.position.y > 0.1)
            {
                moveDirection = -1f;
            }
            else if (rb.position.y < -0.1)
            {
                moveDirection = 1f;
            }
            else if (rb.position.y == 0.1 || rb.position.y == -0.1)
            {
                moveDirection = 0f;
            }

            rb.linearVelocityY = moveDirection * (paddleSpeed / 2);

        }
    }
}
