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

    public static int enemyCount = 0;
    public static int scoreCount = 0; 

    // Objective variables
    // Destroy Objecive
    GameObject destroyObjectiveTarget;

    // 

    // Use this for initialization
	void Start () {
        scoreCount = 0;
        enemyCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}