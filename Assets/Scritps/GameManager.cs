using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance { get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
                if (instance == null) {
                    GameObject go = new GameObject("Game Manager", typeof(GameManager));
                    instance = go.GetComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    // Objective variables
    // Destroy Objecive
    GameObject destroyObjectiveTarget;

    // 

    public Objective currentObjective;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (currentObjective != null) {
            // Check objective conditions
            switch(currentObjective.type) {
                case ObjectiveType.DestroyMission: {
                    // Check if object is destored
                } break;

                case ObjectiveType.CollectionMission: {
                    // Check if correct amount of objects of a type are gathered.
                } break;
            }
        }
	}

    public void PickedUpItem(GameObject item) {
    }

    public void DestroyEnemy(GameObject enemy) {
        if (destroyObjectiveTarget == enemy) {
            // Success!!!
        }
        Destroy(enemy);
    }
}