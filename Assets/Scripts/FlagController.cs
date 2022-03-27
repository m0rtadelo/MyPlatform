using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelCompleted;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            LevelCompleted.SetActive(true);
        }
    }
}
