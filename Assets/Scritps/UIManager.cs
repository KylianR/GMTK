using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public string formatText = "{0} Km/h";
    public Text speedText;
    public Transform player;

    public Vector3 prevPosition;

	// Use this for initialization
	void Start () {
        if (player == null) {
            player = GameObject.FindWithTag("Player").transform;
        }		
        prevPosition = player.position;
	}
	
	// Update is called once per frame
	void Update () {
		float kmph = player.GetComponent<Rigidbody2D>().velocity.magnitude * 3.6f;
        speedText.text = string.Format(formatText, kmph.ToString("0.00"));
        prevPosition = player.position;
	}
}
