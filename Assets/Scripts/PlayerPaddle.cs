using UnityEngine;


public class PlayerPaddle : MonoBehaviour
{
    private float paddleSpeed = 10f;
    public Rigidbody2D rb;
    public GameManager gameManager;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();      
    
    }

    private void FixedUpdate()
    {
        movePaddle();
        if (rb.position.y > 4.0f)
        {
            rb.position = new Vector2(rb.position.x, 4.0f);
        }
        else if (rb.position.y < -4.0f)
        {
            rb.position = new Vector2(rb.position.x, -4.0f);
        }
        
    }    
    private void OnCollisionEnter2D(Collision2D collision)
    {       
    
        if (collision.gameObject.name == "Ball")
        {
            gameManager.enemyCanMove = true;
            
        }
    }
    private void movePaddle()
    {
        float moveInput = Input.GetAxis("Vertical");
        rb.linearVelocityY = moveInput * paddleSpeed;
    }
}
