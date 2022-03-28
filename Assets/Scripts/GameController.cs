using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject go;
    private Text TextPoints;
    private int Points;

    public void AddPoints(int value) {
        Points += value;
        TextPoints.text = Points.ToString();
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        TextPoints = go.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
