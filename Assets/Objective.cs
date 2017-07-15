using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Condition : ScriptableObject {
    public bool completed { get { return IsCompleted(); } }
    public abstract bool IsCompleted();
}

[CreateAssetMenu(fileName = "Destroy Condition", menuName = "Conditions/Destroy Condition", order = 1)]
[System.Serializable]
public class DestroyCondition : Condition {
    public int targetAmount = 1;
    public int currentAmount = 0;
    public string prefabName;

    public override bool IsCompleted() {
         return (currentAmount >= targetAmount);
    }
}

public  enum ObjectiveType {
    EscortMission,
    LiberateMission,
    ExcapeMission,
    CollectionMission,
    BasePartMission,
    DefendMission,
    DestroyMission,
    TargetMission,
}

[CreateAssetMenu(fileName = "Objective", menuName = "Objective", order = 1)]
[System.Serializable]
public class Objective : ScriptableObject {
    public bool completed {
        get {
            foreach(Condition item in conditions) {
                if (!item.completed) return false;
            }
            return true;
        }
    }
    
    public ObjectiveType type;

    public new string name;

    [TextArea()]
    public string description;

    public int reward;

    List<Condition> conditions = new List<Condition>();
}