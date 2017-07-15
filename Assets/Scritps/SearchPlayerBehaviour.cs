using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayerBehaviour : MonoBehaviour {

    public float speed = 10;
    public bool minDistance = true;
    public float minPlayerDist = 100;

    Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!minDistance || (minDistance && Vector3.Distance(
            transform.position, player.position) <= minPlayerDist)) {
            transform.position = Vector3.MoveTowards(transform.position, 
                player.position, speed * Time.deltaTime);

            // Rotate towards the player
            Vector3 diff = (player.position - transform.position);
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
	}
}
