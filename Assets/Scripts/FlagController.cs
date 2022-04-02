using System.Collections;
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
            StartCoroutine(NextLevel());
        }
    }
    IEnumerator NextLevel() {
        yield return new WaitForSeconds(5);
        gc.nextLevel();
    }

    private void Start() {
        Game = GameObject.Find("Game");
        gc = Game.GetComponent<GameController>();
    }
}
