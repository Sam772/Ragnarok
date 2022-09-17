using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Bolster Defence Skill")]
public class BolsterDefenceSkill : ScriptableSkill {
    public override void Activate(ScriptablePlayer player) {
        var playerStats = player.Prefab.Stats;

        if (playerStats.CurrentSkillPoints < 3) {
            GameManager.Instance.GameHUD.SetGameStatusText("You do not have enough SP to use this skill!");
        } else {
            playerStats.Defence += 2;
            playerStats.CurrentSkillPoints -= 3;

            player.Prefab.SetStats(playerStats);
            
            GameManager.Instance.GameHUD.PlayerHUD.SetSkillPointsText("SP: " + playerStats.CurrentSkillPoints.ToString());
        }

        GameManager.Instance.GameHUD.SetGameStatusText(player.ScriptableCharacterName + " used " + SkillAttributes.SkillName + "!");
    }
}
