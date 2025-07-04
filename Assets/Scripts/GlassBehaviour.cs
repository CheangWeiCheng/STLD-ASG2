using UnityEngine;

public class GlassBehaviour : MonoBehaviour
{
    [SerializeField]
    AudioClip boxHitAudioClip; // Reference to the AudioClip component for playing sounds

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
            Destroy(collision.gameObject); // Destroy the projectile
            Destroy(this.gameObject); // Destroy the box
        }
    }
}
