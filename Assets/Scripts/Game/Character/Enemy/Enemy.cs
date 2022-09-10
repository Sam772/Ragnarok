using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
    // This script represents an enemy character which derives from a base character

    public override void TakeDamage(ScriptablePlayer player, ScriptableEnemy enemy) {

        player.Prefab.CharacterAction = CharacterAction.Attacking;

        var playerStats = player.Prefab.Stats;
        var enemyStats = enemy.Prefab.Stats;

        int damage = playerStats.Strength - enemyStats.Defence;

        if (player.Prefab.CharacterAction == CharacterAction.Defending) {
            damage /= 2;
        }

        if (damage <= 0) {
            damage = 1;
        }
        
        enemyStats.CurrentHealth -= damage;
        //print("enemy health: " + enemyStats.CurrentHealth);

        SetStats(enemyStats);

        GameManager.Instance.GameHUD.EnemyHUD.SetHealthText("HP: " + enemyStats.CurrentHealth.ToString());
    }

    public override void Defend(ScriptableCharacter enemy) {
        enemy.Prefab.CharacterAction = CharacterAction.Defending;
    }
}
