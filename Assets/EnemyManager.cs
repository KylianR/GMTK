using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private float health = 100;
    public float Health {
        get {
            return health;
        }
        set {
            if (value < health) {
                StartCoroutine(FlashRed());
            }
            if (value <= 0) {
                health = 0;
                Die();
                return;
            }
            health = value;
        }
    }

    public float damage = 10;

    new SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        GameManager.enemyCount++;
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FlashRed() {
        if (renderer.color == Color.white) {
            renderer.color = Color.red;
            yield return new WaitForSeconds(1/30);
            renderer.color = Color.white;
        }
    }

    void Die() {
		GameManager.enemyCount--;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
            Health -= damage;
            Destroy(collision.gameObject);
        }
    }
}
