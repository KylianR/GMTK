using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Button startButton;
    public Button exitButton;

	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(()=> {
            SceneManager.LoadScene("main");
        });
        exitButton.onClick.AddListener(()=> {
            Application.Quit();
        });
	}
}
