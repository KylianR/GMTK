using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class FloatRange {
    public float min;
    public float max;

    public FloatRange(int min, int max) {
        this.min = min;
        this.max = max;
    }
}

public class AstroidSpawner : MonoBehaviour {

    public FloatRange radius;
    public int count;
    public FloatRange astroidSize;

    public GameObject asteroidPrefab;
    private List<GameObject> asteroids = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Generate() {
        // Remove old asteroids
        foreach(Transform child in transform) {
            DestroyImmediate(child.gameObject);
        }
        asteroids.Clear();

        // Generate new asteroids
        for (int astroidIndex = 0; astroidIndex < count; astroidIndex++) {
            GameObject asteroid = Instantiate<GameObject>(asteroidPrefab, this.transform);
            asteroid.transform.position = Random.insideUnitCircle * Random.Range(radius.min, radius.max);
            asteroid.transform.localScale = Vector3.one * Random.Range(astroidSize.min, astroidSize.max);
            asteroids.Add(asteroid);
        }
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(AstroidSpawner))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        AstroidSpawner myScript = (AstroidSpawner)target;
        if(GUILayout.Button("Build Object"))
        {
            myScript.Generate();
        }
    }
}
#endif