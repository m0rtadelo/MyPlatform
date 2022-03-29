using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static bool HasEnemies = true;
    [SerializeField]
    private Toggle toggleEnemies;
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void setEnemies() {
        SceneController.HasEnemies = toggleEnemies.isOn;
    }

    private void Start() {
        toggleEnemies.isOn = SceneController.HasEnemies;
    }
}
