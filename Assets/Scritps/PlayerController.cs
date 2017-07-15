using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int shield { get { return shieldBase + shieldUp; } }
    [SerializeField]
    public int firePower { get { return firePowerBase + firePowerUp; } }
    [SerializeField]
    public int fireSpeed { get { return fireSpeedBase + fireSpeedUp; } }

    // The base value
    int shieldBase;
    int firePowerBase;
    int fireSpeedBase;

    // The upgraded or downgraded amounts
    int shieldUp;
    int firePowerUp;
    int fireSpeedUp;

    public GameObject bulletPrefab;
    new Rigidbody2D rigidbody;

    [Range(0.1f, 1000.0f)]
    public float bulletForce;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();

        // Generate values between one and five.
        // You have five to spend
        int toSpend = 7;

        int value = Random.Range(2, Mathf.Min(4, toSpend));
        shieldBase += value;
        toSpend -= value;

        value = Random.Range(2, Mathf.Min(4, toSpend));
        firePowerBase = value;
        toSpend -= value;

        fireSpeedBase = toSpend;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Rotate the player towards the mouse button
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation((transform.position - mousePos), 
                                                      Vector3.forward);
        rotation = Quaternion.Euler(0, 0, rotation.eulerAngles.z);
        transform.rotation = rotation;


		if (Input.GetMouseButtonDown(0)) {
            if (rigidbody.IsSleeping()) {
                rigidbody.WakeUp();
            }
            GameObject bullet = Instantiate(bulletPrefab, transform.position + 
                transform.up, Quaternion.identity);
            Vector2 force = transform.up * bulletForce;
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // These forces should be symetrical!
            bulletRigidbody.AddForce(force, ForceMode2D.Impulse);
            rigidbody.AddForce(-force, ForceMode2D.Impulse);
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        switch (other.gameObject.tag) {
        // Effect fields
        case "Shield Field":
            shieldUp += 1;
            break;
        case "Damage Field":
            firePowerUp += 1;
            break;
        case "Speed Field":
            fireSpeedUp += 1;
            break;
        
        // Base
        case "Base":
            FindObjectOfType<UIManager>().TurnGoalPanelOn();
            // Stop that shizl
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            rigidbody.velocity = Vector3.zero;
            rigidbody.Sleep();
            break;
        }

    }

    void OnTriggerExit2D(Collider2D other) {
        switch (other.gameObject.tag) {
        // Effect fields
        case "Shield Field":
            shieldUp -= 1;
            break;
        case "Damage Field":
            firePowerUp -= 1;
            break;
        case "Speed Field":
            fireSpeedUp -= 1;
            break;

        // Base
        case "Base":
            FindObjectOfType<UIManager>().TurnGoalPanelOff();
            break;
        }
    }
}
