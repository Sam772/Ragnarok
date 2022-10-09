using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Goblin Punch Skill")]
public class GoblinPunchSkill : ScriptableGoblinSkills {
    public override void Activate(ScriptableCharacter enemy) {
        
        var player = CharacterManager.Instance.PlayableCharacterScriptable;

        var playerStats = player.Prefab.Stats;
        var enemyStats = enemy.Prefab.Stats;

        if (enemyStats.CurrentSkillPoints < 2) {
            GameManager.Instance.GameHUD.SetGameStatusText("You do not have enough SP to use this skill!");
        
            // go back to enemy

            //GameManager.Instance.SetState(new EnemyTurn(GameManager.Instance));
        } else {
            GameManager.Instance.GameHUD.SetGameStatusText(enemy.ScriptableCharacterName + " used " + SkillAttributes.SkillName + "!");

            SkillState = SkillState.Activating;

            int damage = (enemyStats.Strength + 2) - playerStats.Defence;

            enemyStats.CurrentSkillPoints -= 3;

            if (player.Prefab.CharacterAction == CharacterAction.Defending) {
                damage /= 2;
            }

            if (damage <= 0) { 
                damage = 1;
            }

            playerStats.CurrentHealth -= damage;

            enemy.Prefab.SetStats(enemyStats);
            player.Prefab.SetStats(playerStats);

            GameManager.Instance.GameHUD.EnemyHUD.SetSkillPointsText("SP: " + enemyStats.CurrentSkillPoints);
            GameManager.Instance.GameHUD.PlayerHUD.SetHealthText("HP: " + playerStats.CurrentHealth);
        }
    }
}
