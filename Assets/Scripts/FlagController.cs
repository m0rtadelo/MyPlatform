using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelCompleted;
    private GameObject Game;
    private GameController gc;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            LevelCompleted.SetActive(true);
            StartCoroutine(RestartLevel());
        }
    }
    IEnumerator RestartLevel() {
        yield return new WaitForSeconds(5);
        gc.RestartLevel();
    }

    private void Start() {
        Game = GameObject.Find("Game");
        gc = Game.GetComponent<GameController>();
    }
}
