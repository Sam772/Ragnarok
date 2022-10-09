using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableBerserkerSkills : ScriptableSkill {
    public BerserkerSkills BerserkerSkills;
}

[Serializable]
public enum BerserkerSkills {
    VigorUp = 0
}