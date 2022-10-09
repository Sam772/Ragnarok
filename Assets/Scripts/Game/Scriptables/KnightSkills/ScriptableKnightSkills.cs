using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableKnightSkills : ScriptableSkill {
    public KnightSkills KnightSkills;
}

[Serializable]
public enum KnightSkills {
    BolsterDefence = 1,
    FatalThrust = 2,
}