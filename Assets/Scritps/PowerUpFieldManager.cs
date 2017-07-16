using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PowerUpFieldManager : MonoBehaviour {

    PolygonCollider2D polygon;
    new MeshRenderer renderer;
    MeshFilter filter;

    Mesh mesh;

    List<Vector3> vertices;

	// Use this for initialization
	void Start () {
		polygon = GetComponent<PolygonCollider2D>();
		renderer = GetComponent<MeshRenderer>();
        filter = GetComponent<MeshFilter>();

        Generate();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    internal void Generate() {
        polygon = GetComponent<PolygonCollider2D>();
		renderer = GetComponent<MeshRenderer>();
        filter = GetComponent<MeshFilter>();

        mesh = new Mesh();
        vertices = new List<Vector3>(polygon.points.Length);
        foreach(Vector2 point in polygon.points) {
            vertices.Add(point);
        }
        Triangulator tr = new Triangulator(polygon.points);

        mesh.SetVertices(vertices);
        mesh.SetTriangles(tr.Triangulate(), 0);
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        filter.mesh = mesh;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PowerUpFieldManager))]
public class PowerUpFieldManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        PowerUpFieldManager myScript = (PowerUpFieldManager)target;
        if(GUILayout.Button("Build Mesh"))
        {
            myScript.Generate();
        }
    }
}
#endif
