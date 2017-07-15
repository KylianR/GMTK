using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour {

    public float enemySafeRadius = 100;
    public float enemyEasyRadius = 300;
    public float enemyMediumRadius = 500;
    public float enemyHardRadius = 1500;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemySafeRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyEasyRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyMediumRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyHardRadius);
    }
}
