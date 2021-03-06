﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayerBehaviour : MonoBehaviour {

    public float playerSpeedMultiplier = 0.475f;
    public float distanceToPlayer = 20;

    Transform player;
    Rigidbody2D playerRigid;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
        playerRigid = player.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float speed = 15 + (playerRigid.velocity.magnitude) * playerSpeedMultiplier; 
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > distanceToPlayer) {
            transform.position = Vector3.MoveTowards(transform.position, 
                player.position, speed * Time.deltaTime);
        }

        // Rotate towards the player
        Vector3 diff = (player.position - transform.position);
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
