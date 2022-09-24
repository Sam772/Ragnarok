using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player {
    [SerializeField] private BolsterDefenceSkill _bolsterDefenceSkill;
    public BolsterDefenceSkill BolsterDefenceSkill => _bolsterDefenceSkill;

    // get the array of skills from scriptableplayer instead

    public override void ActivateSkill(ScriptablePlayer player) {
        CharacterAction = CharacterAction.ActivatingSkill;

        BolsterDefenceSkill.Activate(player);
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
