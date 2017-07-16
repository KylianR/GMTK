using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Button startButton;
    public Button exitButton;

    private string formatString;
    public Text scoreText;

	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(()=> {
            SceneManager.LoadScene("main");
        });
        exitButton.onClick.AddListener(()=> {
            Application.Quit();
        });
	}

    void OnEnable() {
        if (scoreText != null) {
            formatString = scoreText.text;
            scoreText.text = string.Format(formatString, GameManager.scoreCount);
        }
    }
}
