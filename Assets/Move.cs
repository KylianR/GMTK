using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public int hp = 100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += new Vector3(0, Input.GetAxis("Vertical"), 0); 
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp = hp - 5;

        if (hp == 0)
        {
            Destroy(this.gameObject);
        }

    }
}
