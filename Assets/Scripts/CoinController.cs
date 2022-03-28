using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Coin trigger " + other);
        if (other.gameObject.tag.Equals("Player")) {
            Instantiate(prefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
