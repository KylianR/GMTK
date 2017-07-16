using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasRenderer))]
public class TriangleRenderer : MonoBehaviour {

    public float maxLength = 50f;
    public Vector3[] points = new Vector3[3];

    [Range(0.1f, 50)]
    public float shield;    // V3 (Up)
    [Range(0.1f, 50)]
    public float fireRate;  // V2 (Right)
    [Range(0.1f, 50)]
    public float firePower; // V1 (Left)

    new CanvasRenderer renderer;
    public Material material;
    public Mesh mesh;

    public PlayerController player;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<CanvasRenderer>();

        mesh = new Mesh();
        mesh.SetVertices(new List<Vector3>(points));
        mesh.SetTriangles(new int[] {0, 1, 2}, 0);
        renderer.Clear();
        renderer.SetMaterial(material, null);
        renderer.SetMesh(mesh);

        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        shield = player.shield * (maxLength / 5);
        fireRate = player.fireSpeed * (maxLength / 5);
        firePower = PlayerController.firePower * (maxLength / 5);

        points[2].y = Mathf.Clamp(shield, 0, maxLength);

        float angle = 0.50709850f;
        float valRight = Mathf.Clamp(fireRate, 0.1f, maxLength);
        points[1].x = valRight * Mathf.Cos(angle);
        points[1].y = -valRight * Mathf.Sin(angle);

        float valLeft = Mathf.Clamp(firePower, 0.1f, maxLength);
        points[0].x = -valLeft * Mathf.Cos(angle);
        points[0].y = -valLeft * Mathf.Sin(angle);

        mesh.SetVertices(new List<Vector3>(points));
        renderer.SetMesh(mesh);
	}

    private void OnDrawGizmos() {
        foreach(Vector3 point in points) {
            Gizmos.DrawSphere(point, 0.1f);
        }
    }
}
