using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	public static ScreenShake Instance;

    /// <summary>
    /// Amount of space the camera moves
    /// </summary>
	public  float amplitude = 0.1f;

    /// <summary>
    /// The start position of the camera to return here
    /// </summary>
	private Vector3 originalPosition;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		originalPosition = transform.localPosition;	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void Shake(float amplitude, float time)
	{
		StartCoroutine(DoShake(time, amplitude));
	}

	IEnumerator DoShake(float time, float ampliude)
	{
		// Variable to measure the time with
		float t = 0.0f;
		// As long as we haven't exeeded the shake time
		while(t < time)
		{
			// Add the delta time to our time keeper
			t += Time.deltaTime;
			// Jump to random position
			transform.localPosition += Random.insideUnitSphere * amplitude;
			// Goto next frame
			yield return null;
		}
	}
}
