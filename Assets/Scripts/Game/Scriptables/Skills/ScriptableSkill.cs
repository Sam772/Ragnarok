using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Scriptable Character Skill")]
public class ScriptableSkill : ScriptableObject {
    [SerializeField] private SkillAttributes _skillAttributes;
    public SkillAttributes SkillAttributes => _skillAttributes;
    
    public virtual void Activate(ScriptablePlayer player) { }
}

[Serializable]
public struct SkillAttributes {
    public string SkillName;
    public string SkillDescription;
    public int SkillCost;
}

