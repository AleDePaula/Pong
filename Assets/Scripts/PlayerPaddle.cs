using UnityEngine;


public class PlayerPaddle : MonoBehaviour
{
    private float paddleSpeed = 10f;
    public Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    
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
    
    private void movePaddle()
    {
        float moveInput = Input.GetAxis("Vertical");
        rb.linearVelocityY = moveInput * paddleSpeed;
    }
}
