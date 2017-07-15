using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
