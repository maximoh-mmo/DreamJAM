using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Normalize the direction vector to ensure consistent speed in all directions
        moveDirection.Normalize();

        // Move the object based on input
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}