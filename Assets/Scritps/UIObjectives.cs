using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIObjectives : MonoBehaviour {

    public RectTransform contentContainer;
    public GameObject objectivePrefab;

	// Use this for initialization
	void Start () {
        UIManager uiManager = FindObjectOfType<UIManager>();

		Objective[] objectives = Resources.LoadAll<Objective>("Objectives/");
        foreach(Objective o in objectives) {
            GameObject uiElement = Instantiate(objectivePrefab, contentContainer);
            uiElement.transform.Find("Container/NameText").GetComponent<Text>().text = 
                o.name;
            uiElement.transform.Find("Container/DescrText").GetComponent<Text>().text = 
                o.description;
            uiElement.transform.Find("Container/RewardText").GetComponent<Text>().text = 
                "Reward: " + o.reward;
            // Register button
            Objective objective = o;
            uiElement.GetComponent<Button>().onClick.AddListener(()=> {
                GameManager.Instance.currentObjective = objective;
                Destroy(uiElement);
                uiManager.TurnGoalPanelOff();
            });
        }
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}