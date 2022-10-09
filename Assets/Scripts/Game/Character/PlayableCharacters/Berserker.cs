using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Player {

    public override void ActivateSkill(ScriptableCharacter player) {
        CharacterAction = CharacterAction.UsingSkill;

        Skills[0].Activate(player);
    }

    public override void SetNewStats(ScriptablePlayer player) {
        // increase stats
        var playerStats = player.BaseStats;

        playerStats.MaxHealth += 10;
        playerStats.Strength += 4;
        playerStats.Defence += 1;
        playerStats .MaxSkillPoints += 2;

        player.Prefab.SetStats(playerStats);

        GameManager.Instance.GameHUD.PlayerHUD.SetHealthText("HP: " + playerStats.MaxHealth);
        GameManager.Instance.GameHUD.PlayerHUD.SetSkillPointsText("SP: " + playerStats.MaxSkillPoints);
    }
}
