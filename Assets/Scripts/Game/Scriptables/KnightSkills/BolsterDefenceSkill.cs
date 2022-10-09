using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Bolster Defence Skill")]
public class BolsterDefenceSkill : ScriptableKnightSkills {
    public override void Activate(ScriptableCharacter player) {
        var playerStats = player.Prefab.Stats;

        if (playerStats.CurrentSkillPoints < 3) {
            GameManager.Instance.GameHUD.SetGameStatusText("You do not have enough SP to use this skill!");

            // go back to playerturn

            //GameManager.Instance.SetState(new PlayerTurn(GameManager.Instance));

        } else {
            GameManager.Instance.GameHUD.SetGameStatusText(player.ScriptableCharacterName + " used " + SkillAttributes.SkillName + "!");

            SkillState = SkillState.Activating;

            playerStats.Defence += 2;
            playerStats.CurrentSkillPoints -= 3;

            player.Prefab.SetStats(playerStats);
            
            GameManager.Instance.GameHUD.PlayerHUD.SetSkillPointsText("SP: " + playerStats.CurrentSkillPoints.ToString());
        }
    }
}
