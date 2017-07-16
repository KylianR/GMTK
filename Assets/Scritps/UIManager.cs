using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text objectiveText;

    [Header("Speedometer")]
    public string formatText = "{0} Km/h";
    public Text speedText;
    public Transform player;

    [Header("Targeting")]
    public int offset = 10;
    public GameObject uiTargetPrefab;

    public int lastTargetCount = 0;
    public List<Transform> targets = new List<Transform>();
    public List<RectTransform> uiTargets = new List<RectTransform>();

    [Header("Health")]
    private RectTransform sliderRect;
    public Slider slider;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
        if (player == null) {
            player = GameObject.FindWithTag("Player").transform;
        }

        sliderRect = slider.GetComponent<RectTransform>();

        UpdateTargets();
        InvokeRepeating("UpdateTargets", 0, 10);
	}
	
	// Update is called once per frame
	void Update () {
        slider.maxValue = 100;
        slider.value = playerController.Health;

		float kmph = player.GetComponent<Rigidbody2D>().velocity.magnitude * 3.6f;
        speedText.text = string.Format(formatText, kmph.ToString("0.00"));

        objectiveText.text = "Remaining Enemies: " + GameManager.enemyCount + "            " + "Score: " + GameManager.scoreCount;

        // Do UI things
        for (int targetIndex = 0; targetIndex < targets.Count; targetIndex++) {
            Transform target = targets[targetIndex];
            if (uiTargets.Count - 1 < targetIndex) { break; }
            if (target != null) {
                Vector3 targetPos = target.transform.position;
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(targetPos);

                // Remove uitarget from screen if inside the view area.
                if (positionOnScreen.x > 0 && positionOnScreen.x < 1 &&
                    positionOnScreen.y > 0 && positionOnScreen.y < 1) {
                    uiTargets[targetIndex].anchoredPosition = new Vector2(-10, -10);
                } else {
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
            } else {
                targets.Remove(target);
            }
        }
	}

    void UpdateTargets() {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length != lastTargetCount) {
            lastTargetCount = gos.Length;
            targets.Clear();
            for (int i = 0; i < gos.Length; i++) {
                if (i > uiTargets.Count) {
                    GameObject targetObject = Instantiate(uiTargetPrefab, this.transform);
                    uiTargets.Add(targetObject.GetComponent<RectTransform>());
                }
                Transform target = gos[i].transform;
                targets.Add(target);
            }
        }
    }
}
