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
    public float bulletDelay = 0.2f;
    float lastShotTime;

    BaseManager baseManager;

    [SerializeField]
    public bool dead;
    private float health;
    public float Health {
        get {
            return health;
        }
        set {
            if (value < health) {
                StartCoroutine(FlashRed());
            }
            if (value < 0) {
                health = 0;
                Die();
                return;
            }
            health = value;
        }
    }
    public float healRate = 60;
    float bulletDamage = 10;
    float collisionDamage = 5;

    new SpriteRenderer renderer;
    
    private void Die() {
        dead = true;
        PlayerPrefs.SetInt("Score ", GameManager.scoreCount);
    }

    // Use this for initialization
    void Start () {
        renderer = GetComponent<SpriteRenderer>();
		rigidbody = GetComponent<Rigidbody2D>();
        baseManager = FindObjectOfType<BaseManager>();

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

        // 
        Health = 100;

        lastShotTime = Time.time;
	}

    void Update() {
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (dead) return;

        // Rotate the player towards the mouse button
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation((transform.position - mousePos), 
                                                      Vector3.forward);
        rotation = Quaternion.Euler(0, 0, rotation.eulerAngles.z);
        transform.rotation = rotation;
        
        float baseDistance = Vector3.Distance(transform.position, 
                                              baseManager.transform.position);
        if (baseDistance > baseManager.enemyHardRadius) {
            float magnitude = baseDistance - baseManager.enemyHardRadius;
            rigidbody.AddForce((baseManager.transform.position - transform.position) *
                               magnitude);
        }

		if (Input.GetMouseButtonDown(0)) {
            if (rigidbody.IsSleeping()) {
                rigidbody.WakeUp();
            }
            Shoot();

        }
        if (Input.GetMouseButton(0)) {
            if (Time.time - lastShotTime > (bulletDelay / fireSpeed)) {
                lastShotTime = Time.time;
                Shoot();
            }
        } else {
            health += healRate * shield * Time.deltaTime;
            if (health > 100) {
                health = 100;
            }
        }
	}

    IEnumerator FlashRed() {
        ScreenShake.Instance.Shake(0.3f, 0.1f);
        if (renderer.color == Color.white) {
            renderer.color = Color.red;
            yield return new WaitForSeconds(1/30);
            renderer.color = Color.white;
        }
    }

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + 
            transform.up, Quaternion.identity);
        Vector2 force = transform.up * bulletForce;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // These forces should be symetrical!
        bulletRigidbody.AddForce(force, ForceMode2D.Impulse);
        rigidbody.AddForce(-force, ForceMode2D.Impulse);
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            Health -= bulletDamage / shield;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name.Contains("Enemy 3"))
        {
            Destroy(collision.gameObject);
            Health -= bulletDamage / shield;
        }
    }        
}
