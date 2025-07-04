/*
* Author: Cheang Wei Cheng
* Date: 14 June 2025
* Description: This script controls the behavior of breakable boxes in the game. When hit by a projectile (tagged as "Projectile"), 
* the box will be destroyed and spawn a coin at its position. The projectile is also destroyed upon impact. 
* This script works in conjunction with other game scripts to create an interactive environment where players can 
* shoot projectiles at boxes to collect coins. The coin prefab to be spawned is configurable through the Unity Inspector.
*/

using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    [SerializeField]
    AudioClip boxHitAudioClip; // Reference to the AudioClip component for playing sounds
    public GameObject coin;

    /// <summary>
    /// Method called when this GameObject collides with another GameObject.
    /// Checks if the collision is with a projectile (tagged as "Projectile").
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Box has been hit.");
            AudioSource.PlayClipAtPoint(boxHitAudioClip, transform.position); // Play the box hit sound
            // Spawn a coin at the box's position
            var spawnedCoin = Instantiate(coin, transform.position, coin.transform.rotation);
            Destroy(collision.gameObject); // Destroy the projectile
            Destroy(this.gameObject); // Destroy the box
        }
    }
}
