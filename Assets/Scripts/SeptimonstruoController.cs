using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeptimonstruoController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player) {
            player.Die();
        }
    }
}
