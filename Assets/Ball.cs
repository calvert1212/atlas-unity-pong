using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxBounceAngle = 45f;
    public float paddleHitDistance = 2f;
    public float speed = 10f;  // Speed of the ball
    public float resetTime = 1f;  // Time to wait before resetting the ball

    private Rigidbody2D rb;
    private Vector2 initialDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    // Launch the ball in a random direction
    void LaunchBall()
    {
        // Randomly choose a direction
        float angle = Random.Range(0f, 360f);
        initialDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

        // Apply force to the ball
        rb.velocity = initialDirection * speed;
    }

    // Reset the ball to the center of the screen
    public void ResetBall()
    {
        // Stop the ball's movement
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        // Wait for the resetTime before launching again
        Invoke("LaunchBall", resetTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Paddle"))
    {
        // Calculate the point of contact on the paddle
        float hitPointY = collision.contacts[0].point.y;
        
        // Get the paddle's center Y position
        float paddleCenterY = collision.transform.position.y;

        // Calculate the difference between the hit point and the paddle's center
        float distanceFromCenter = hitPointY - paddleCenterY;

        // Normalize the distance relative to the height of the paddle
        float normalizedDistance = distanceFromCenter / (collision.collider.bounds.size.y / 2);

        // Limit the bounce angle
        float bounceAngle = normalizedDistance * maxBounceAngle;

        // Calculate the new direction based on the bounce angle
        Vector2 currentDirection = rb.velocity.normalized; // Current direction of the ball
        Vector2 newDirection = new Vector2(currentDirection.x, Mathf.Sin(Mathf.Deg2Rad * bounceAngle)).normalized;

        // Apply the new direction to the ball's velocity
        rb.velocity = newDirection * rb.velocity.magnitude;  // Maintain the ball's current speed
    }
}
}