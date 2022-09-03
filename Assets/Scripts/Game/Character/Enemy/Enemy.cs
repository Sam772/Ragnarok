using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
    // This script represents an enemy character which derives from a base character

    public override void TakeDamage(int targetStrength, int myDefence) {
        int damage = targetStrength - myDefence;
        if (damage <= 0) damage = 1;

        var enemy = CharacterManager.Instance.EnemyScriptable;
        var stats = enemy.BaseStats;
        
        stats.CurrentHealth -= damage;

        SetStats(stats);

        GameManager.Instance.EnemyHUD.SetHealthText("HP: " + stats.CurrentHealth.ToString());
    }
}
