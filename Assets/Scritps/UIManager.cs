using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text objectiveText;
    public RectTransform goalPanel;

    [Header("Speedometer")]
    public string formatText = "{0} Km/h";
    public Text speedText;
    public Transform player;

    [Header("Targeting")]
    public int offset = 10;
    public GameObject uiTargetPrefab;
    public List<Transform> targets;
    public List<RectTransform> uiTargets = new List<RectTransform>();

	// Use this for initialization
	void Start () {
        if (player == null) {
            player = GameObject.FindWithTag("Player").transform;
        }		

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject go in gos) {
            Transform target = go.transform;
            targets.Add(target);

            GameObject targetObject = Instantiate(uiTargetPrefab, this.transform);
            uiTargets.Add(targetObject.GetComponent<RectTransform>());
        }
	}
	
	// Update is called once per frame
	void Update () {
		float kmph = player.GetComponent<Rigidbody2D>().velocity.magnitude * 3.6f;
        speedText.text = string.Format(formatText, kmph.ToString("0.00"));

        // Do UI things
        for (int targetIndex = 0; targetIndex < targets.Count; targetIndex++) {
            Vector3 targetPos = targets[targetIndex].transform.position;
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(targetPos);
            Vector2 clampedScreenPos = new Vector2(
                offset + Mathf.Clamp01(positionOnScreen.x) * (Screen.width - 2*offset), 
                offset + Mathf.Clamp01(positionOnScreen.y) * (Screen.height - 2*offset));
            RectTransform uiTarget = uiTargets[targetIndex];
            uiTarget.anchoredPosition = clampedScreenPos;

            Vector3 scaledPositionOnScreen = new Vector3(positionOnScreen.x * Screen.width,
                                                         positionOnScreen.y * Screen.height);
            Vector3 diff = (scaledPositionOnScreen - uiTarget.position);
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
            uiTargets[targetIndex].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
	}
}
