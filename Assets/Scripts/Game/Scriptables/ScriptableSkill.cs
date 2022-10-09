using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Scriptable Character Skill")]
public class ScriptableSkill : ScriptableObject {
    [SerializeField] private SkillAttributes _skillAttributes;
    public SkillAttributes SkillAttributes => _skillAttributes;
    public SkillState SkillState;
    private bool _isUnlocked = false;

    public virtual void Activate(ScriptableCharacter player) { }
    public void UnlockSkill() => _isUnlocked = true;
}

[Serializable]
public struct SkillAttributes {
    public string SkillName;
    public string SkillDescription;
    public int SkillCost;
}

[Serializable]
public enum SkillState {
    Dormant = 0,
    Activating = 1,
    Cooldown = 2,
    InUse = 3
}

