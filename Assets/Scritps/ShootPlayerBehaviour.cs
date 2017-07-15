using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayerBehaviour : MonoBehaviour {

    public float minPlayerDist = 100;
    public float bulletSpeed = 100;
    public GameObject bulletPrefab;
    public FloatRange salvoSize = new FloatRange(3, 8);
    public FloatRange shootDelay = new FloatRange(2, 5);

    Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(ShootPlayer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ShootPlayer() {
        if (Vector3.Distance(transform.position, player.position) <= minPlayerDist) {
            int count = Random.Range((int)salvoSize.min, (int)salvoSize.max);
            for(int i = 0; i < count; i++) {
                GameObject bullet = Instantiate(bulletPrefab, 
                    transform.position + transform.forward, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 
                    bulletSpeed, ForceMode2D.Impulse);
            }
        }
        yield return new WaitForSeconds(Random.Range(shootDelay.min, 
                                                     shootDelay.max));
        yield return StartCoroutine(ShootPlayer());
    }
}
