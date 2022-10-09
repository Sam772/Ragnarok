using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Character : MonoBehaviour, ICharacter {
    // This scripts represents the base character class used for both players and enemies
    public CharacterAction CharacterAction;
    public Stats Stats { get; private set; }
    public List<ScriptableSkill> Skills { get; private set; }

    public void SetStats(Stats stats) {
        Stats = stats;
    }

    public void SetSkills(List<ScriptableSkill> skills) {
        Skills = skills;
    }

    public bool CheckIfDead(Character character) {
        if (Stats.CurrentHealth <= 0)
            return true;
        else
            return false;
    }

    public virtual void TakeDamage(ScriptablePlayer player, ScriptableEnemy enemy) { }

    public virtual void Defend(ScriptableCharacter character) { }

    public virtual void SetNewStats(ScriptablePlayer player) { }

    public virtual void ActivateSkill(ScriptableCharacter player) { }
}

public enum CharacterAction {
    Idling = 0,
    Attacking = 1,
    Defending = 2,
    UsingSkill = 3,
}
