using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Player {
    [SerializeField] private VigorUpSkill _vigorUpSkill;
    public VigorUpSkill VigorUpSkill => _vigorUpSkill;

    public override void ActivateSkill(ScriptablePlayer player) {
        CharacterAction = CharacterAction.ActivatingSkill;
        
        VigorUpSkill.Activate(player);
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
