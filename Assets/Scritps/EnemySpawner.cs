﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    BaseManager homeBase;

    public int maxEnemies = 1000;
    public float spawnRadius = 10;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    
	// Use this for initialization
	void Start () {
		homeBase = FindObjectOfType<BaseManager>();
        StartCoroutine(SpawnEnemies());

    }
	
	// Update is called once per frame
	void Update () {
		 
	}

    IEnumerator SpawnEnemies() {


        if (GameManager.enemyCount < maxEnemies) {

            //yield return new WaitForSeconds(Random.Range(1.5f, 5.0f))

            float enemychoice = Random.Range(0f, 2.4f);
            if(enemychoice < 1.5){
                int count = Random.Range(12, 18);
                for (int i = 0; i < count; i++)
                {
                    float loc = Random.Range(0f, 2 * 3.1415926535897932384626f);
                    float dist = Random.Range(150.0f, 350.0f);
                    Vector3 point = new Vector3(Mathf.Cos(loc), Mathf.Sin(loc)) * dist;
                    Vector3 location = transform.position + point;
                    Instantiate(enemy3, location, Quaternion.identity);
                }
            }

            

            if(enemychoice < 2 && enemychoice >= 1.5){
                int count = Random.Range(7, 10);
                for (int i = 0; i < count; i++)
                {
                    float loc = Random.Range(0f, 2 * 3.1415926535897932384626f);
                    float dist = Random.Range(150.0f, 350.0f);
                    Vector3 point = new Vector3(Mathf.Cos(loc), Mathf.Sin(loc)) * dist;
                    Vector3 location = transform.position + point;
                    Instantiate(enemy2, location, Quaternion.identity);
                }
            }

            if (enemychoice < 2.4 && enemychoice >= 2.0)
            {
                int count = Random.Range(4, 9);
                for (int i = 0; i < count; i++)
                {
                    float loc = Random.Range(0f, 2 * 3.1415926535897932384626f);
                    float dist = Random.Range(50.0f, 350.0f);
                    Vector3 point = new Vector3(Mathf.Cos(loc), Mathf.Sin(loc)) * dist;
                    Vector3 location = transform.position + point;
                    Instantiate(enemy1, location, Quaternion.identity);
                }
            }

            /* float distance = Vector3.Distance(transform.position,
                                             homeBase.transform.position);
           if (distance < homeBase.enemyEasyRadius) {
               // Nothing
           } else if (distance < homeBase.enemyEasyRadius) {
               // Easy
               int count = Random.Range(1, 15);
               for(int i = 0; i < count; i++) {
                   Vector3 point = transform.position + 
                       (Vector3)Random.insideUnitCircle * spawnRadius;
                   Instantiate(enemy1, point, Quaternion.identity);
               }
           } else if (distance < homeBase.enemyMediumRadius) {
               // Medium
               int count = Random.Range(1, 15);
               for(int i = 0; i < count; i++) {
                   Vector3 point = transform.position + 
                       (Vector3)Random.insideUnitCircle * spawnRadius;
                   Instantiate(enemy2, point, Quaternion.identity);
               }
           } else {
               // Hard
               int count = Random.Range(1, 15);
               for(int i = 0; i < count; i++) {
                   Vector3 point = transform.position + 
                       (Vector3)Random.insideUnitCircle * spawnRadius;
                   Instantiate(enemy3, point, Quaternion.identity);
               }
           } */
        }
        yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        yield return StartCoroutine(SpawnEnemies());
    }
}
