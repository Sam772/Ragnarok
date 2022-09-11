using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Character : MonoBehaviour {
    // This scripts represents the base character class used for both players and enemies
    public CharacterAction CharacterAction;
    public Stats Stats { get; private set; }

    public virtual void SetStats(Stats stats) {
        Stats = stats;
    }

    public virtual void TakeDamage(ScriptablePlayer player, ScriptableEnemy enemy) { }

    public virtual void Defend(ScriptableCharacter character) { }

    public bool CheckIfDead(Character character) {
        if (Stats.CurrentHealth <= 0)
            return true;
        else
            return false;
    }
}

public enum CharacterAction {
    Idling = 0,
    Attacking = 1,
    Defending = 2,
    ActivatingSkill = 3
}
