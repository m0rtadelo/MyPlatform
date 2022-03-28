using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    private int Points = 1;

    [SerializeField]
    private GameObject prefab;

    private SoundController sc;
    private GameController gc;

    private void Start() {
        GameObject Game;
        Game = GameObject.Find("Game");
        sc = Game.GetComponent<SoundController>();
        gc = Game.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            Instantiate(prefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            sc.PlayCoin(this.transform.position);
            gc.AddPoints(Points);
        }
    }
}
