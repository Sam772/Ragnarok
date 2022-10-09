using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player {

    public override void ActivateSkill(ScriptableCharacter player) {
        CharacterAction = CharacterAction.UsingSkill;

        // get the skill that is being activated i.e. setselectedskill as the index of the skill list

        Skills[0].Activate(player);
    }

    public override void SetNewStats(ScriptablePlayer player) {
        // increase stats
        var playerStats = player.BaseStats;

        playerStats.MaxHealth += 7;
        playerStats.Strength += 2;
        playerStats.Defence += 3;
        playerStats.MaxSkillPoints += 2;

        player.Prefab.SetStats(playerStats);

        GameManager.Instance.GameHUD.PlayerHUD.SetHealthText("HP: " + playerStats.MaxHealth);
        GameManager.Instance.GameHUD.PlayerHUD.SetSkillPointsText("SP: " + playerStats.MaxSkillPoints);
    }
}
