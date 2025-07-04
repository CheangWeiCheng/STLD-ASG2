/*
* Author: Cheang Wei Cheng
* Date: 14 June 2025
* Description: This script controls the behavior of moving bridges in the game.
* The bridge moves up and down between a specified maximum and minimum height at a constant speed.
* The movement is continuous, and the bridge reverses direction when it reaches either the maximum or minimum height.
*/

using UnityEngine;

public class BridgeMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    float maxY = 2f; // Maximum height of the bridge
    [SerializeField]
    float minY = 0.1f; // Minimum height of the bridge
    float moveSpeed = 1f; // Speed of the bridge movement
    bool isMovingDown; // Flag to determine the direction of movement
    private float initialY; // The starting Y position of the bridge

    private void Start()
    {
        // Store the initial Y position when the game starts
        initialY = transform.position.y;
    }

    /// <summary>
    /// Initializes the bridge's position and movement direction.
    /// Depending on whether the bridge is at the maximum or minimum height,
    /// isMovingDown is set to true or false respectively, and the bridge moves accordingly.
    /// </summary>
    void Update()
    {
        if (transform.position.y >= maxY + initialY)
        {
            // If the bridge reaches the maximum height, start moving down
            isMovingDown = true;
        }
        else if (transform.position.y <= minY + initialY)
        {
            // If the bridge reaches the minimum height, start moving up
            isMovingDown = false;
        }

        if (isMovingDown) transform.position = transform.position - new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
        else transform.position = transform.position + new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
    }
}
