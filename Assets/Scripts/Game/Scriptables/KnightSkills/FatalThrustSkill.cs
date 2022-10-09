using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Fatal Thrust Skill")]
public class FatalThrustSkill : ScriptableKnightSkills {
    public override void Activate(ScriptableCharacter player) {

        var enemy = CharacterManager.Instance.EnemyScriptable;

        var playerStats = player.Prefab.Stats;
        var enemyStats = enemy.Prefab.Stats;

        // Implementation
    }
}
