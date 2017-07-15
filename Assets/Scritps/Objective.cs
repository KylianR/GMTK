using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public ObjectiveType type;

    public new string name;

    [TextArea()]
    public string description;

    public int reward;
}