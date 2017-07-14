using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bulletPrefab;
    new Rigidbody2D rigidbody;

    [Range(0.1f, 1000.0f)]
    public float bulletForce;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Rotate the player towards the mouse button
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation((transform.position - mousePos), Vector3.forward);
        rotation = Quaternion.Euler(0, 0, rotation.eulerAngles.z);
        transform.rotation = rotation;


		if (Input.GetMouseButtonDown(0)) {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.up, Quaternion.identity);
            Vector2 force = transform.up * bulletForce;
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // These forces should be symetrical!
            bulletRigidbody.AddForce(force, ForceMode2D.Impulse);
            rigidbody.AddForce(-force, ForceMode2D.Impulse);
        }
	}
}
