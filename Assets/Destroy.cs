using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    
    void Update()
    {
        transform.position += new Vector3(Random.Range(-0.08f, 0.05f),0,0);
        transform.position += new Vector3(0, (Random.Range(-0.04f, 0.07f)), 0);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);
    }
    }
