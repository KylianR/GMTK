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

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}