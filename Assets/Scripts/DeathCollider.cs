using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player) 
            player.Die();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player) 
            player.Die();
    }
}
