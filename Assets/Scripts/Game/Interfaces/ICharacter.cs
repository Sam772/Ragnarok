using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter {
    void SetStats(Stats stats);
    void SetSkills(List<ScriptableSkill> skills);
    void TakeDamage(ScriptablePlayer player, ScriptableEnemy enemy);
    void Defend(ScriptableCharacter character);
    bool CheckIfDead(Character character);
    void SetNewStats(ScriptablePlayer player);
    void ActivateSkill(ScriptableCharacter player);
}
