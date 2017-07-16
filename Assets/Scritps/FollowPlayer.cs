using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Rigidbody2D playerRigid;
    public float followSpeed = 20;
    public float cameraDistance = 10;

    public FloatRange playerSpeed = new FloatRange(100, 1000);
    public FloatRange cameraSize = new FloatRange(15, 30);

	// Use this for initialization
	void Start () {
		playerRigid = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float kmph = playerRigid.velocity.magnitude * 3.6f;
        float targetSize = cameraSize.min;
        if (kmph > playerSpeed.min) {
            if (kmph < playerSpeed.max) {
                targetSize = Mathf.Lerp(cameraSize.min, cameraSize.max, kmph/playerSpeed.max);
            } else {
                targetSize = cameraSize.max;
            }
        }
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, Time.deltaTime);

        Vector3 targetPos = player.position - Vector3.forward * cameraDistance;
		transform.position = Vector3.Lerp(transform.position, targetPos, 
                                          followSpeed * Time.deltaTime);
	}
}
