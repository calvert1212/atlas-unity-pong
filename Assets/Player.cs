using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey = KeyCode.W;     // The key to move the paddle up
    public KeyCode downKey = KeyCode.S;   // The key to move the paddle down
    public float speed = 10f;             // Speed of paddle movement

    private RectTransform rectTransform;  // Reference to the paddle's RectTransform

    void Start()
    {
        // Get the RectTransform component of the paddle
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Get input for moving the paddle up or down
        if (Input.GetKey(upKey))
        {
            MovePaddle(Vector3.up);
        }
        if (Input.GetKey(downKey))
        {
            MovePaddle(Vector3.down);
        }
    }

    // Method to move the paddle up or down
    void MovePaddle(Vector3 direction)
    {
        // Calculate movement distance
        float moveDistance = speed * Time.deltaTime;

        // Move the paddle by this distance
        rectTransform.localPosition += direction * moveDistance;

        // Clamp the paddle's position within screen boundaries
        float clampedY = Mathf.Clamp(rectTransform.localPosition.y, -Screen.height / 2 + rectTransform.rect.height / 2, Screen.height / 2 - rectTransform.rect.height / 2);

        // Apply the clamped position
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, clampedY, rectTransform.localPosition.z);
    }
}