using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    BaseManager homeBase;

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
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 100) {
            float distance = Vector3.Distance(transform.position,
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
            }
        }

        yield return new WaitForSeconds(Random.Range(5, 10));
        yield return StartCoroutine(SpawnEnemies());
    }
}
