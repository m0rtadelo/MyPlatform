using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Coin trigger " + other);
        if (other.gameObject.tag.Equals("Player")) {
            Destroy(this.gameObject);
        }
    }

}
