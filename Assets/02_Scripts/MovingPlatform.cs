using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 5f; // The total distance the platform will move up and down.
    public float moveSpeed = 2f;    // The speed at which the platform moves.

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector3.up * moveDistance;
    }

    private void Update()
    {
        // Move the platform between the initial and target positions.
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // If the platform reaches the target position, reverse direction.
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            SwapPositions();
        }
    }

    private void SwapPositions()
    {
        Vector3 temp = initialPosition;
        initialPosition = targetPosition;
        targetPosition = temp;
    }
}