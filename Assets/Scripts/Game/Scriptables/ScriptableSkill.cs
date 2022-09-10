using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Character Skill")]
public class ScriptableSkill : ScriptableObject {
    
}

[Serializable]
public struct SkillAttributes {
    public Skill[] Skills;
    public int MaxSkillPoints;
    public int CurrentSkillPoints;
}
