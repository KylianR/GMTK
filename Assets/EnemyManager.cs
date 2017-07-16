using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private float health = 100;
    public float Health {
        get {
            return 100;
        }
        set {
            if (value < 0) {
                health = 0;
                Die();
                return;
            }
            health = value;
        }
    }

    public float damage = 10;

	// Use this for initialization
	void Start () {
		GameManager.enemyCount++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Die() {
		GameManager.enemyCount--;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
            health -= damage;
            Destroy(collision.gameObject);
        }
    }
}
