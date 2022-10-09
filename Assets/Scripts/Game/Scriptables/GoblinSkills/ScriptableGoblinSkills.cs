using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableGoblinSkills : ScriptableSkill {
    public GoblinSkills GoblinSkills;
}

[Serializable]
public enum GoblinSkills {
    GoblinPunch = 0
}