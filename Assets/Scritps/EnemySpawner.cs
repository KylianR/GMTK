using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    BaseManager homeBase;

    public int maxEnemies = 100;
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
            float enemychoice = Random.Range(0f, 2.4f);
            if(enemychoice < 1.5){
                int count = Random.Range(3, 4);
                for (int i = 0; i < count && GameManager.enemyCount < maxEnemies; i++) {
                    float loc = Random.Range(0f, 2 * 3.1415926535897932384626f);
                    float dist = Random.Range(50.0f, 90.0f);
                    Vector3 point = new Vector3(Mathf.Cos(loc), Mathf.Sin(loc)) * dist;
                    Vector3 location = transform.position + point;
                    Instantiate(enemy3, location, Quaternion.identity);
                }
            }           

            if(enemychoice < 2 && enemychoice >= 1.5){
                int count = Random.Range(2, 3);
                for (int i = 0; i < count && GameManager.enemyCount < maxEnemies; i++) {
                    float loc = Random.Range(0f, 2 * 3.1415926535897932384626f);
                    float dist = Random.Range(40.0f, 120.0f);
                    Vector3 point = new Vector3(Mathf.Cos(loc), Mathf.Sin(loc)) * dist;
                    Vector3 location = transform.position + point;
                    Instantiate(enemy2, location, Quaternion.identity);
                }
            }

            if (enemychoice < 2.4 && enemychoice >= 2.0)
            {
                int count = Random.Range(1, 2);
                for (int i = 0; i < count && GameManager.enemyCount < maxEnemies; i++) {
                    float loc = Random.Range(0f, 2 * 3.1415926535897932384626f);
                    float dist = Random.Range(30.0f, 120.0f);
                    Vector3 point = new Vector3(Mathf.Cos(loc), Mathf.Sin(loc)) * dist;
                    Vector3 location = transform.position + point;
                    Instantiate(enemy1, location, Quaternion.identity);
                }
            }
        }
        yield return new WaitForSeconds(Random.Range(0.8f, 3.0f));
        yield return StartCoroutine(SpawnEnemies());
    }
}
