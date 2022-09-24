using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : CharacterHUD {
    // This scripts represents the player ui which derives from a base character ui
    [SerializeField] private TMP_Text _playerLevel;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerHealthText;
    [SerializeField] private TMP_Text _playerSkillPointsText;
    [SerializeField] private TMP_Text _playerSkillSubMenuOptionText;
    [SerializeField] private TMP_Text _playerSkillSubMenuOptionCost;

    public void InitalisePlayer(Character character, ScriptablePlayer player) {
        base.Initalise(character);

        // this is where the max stats are actually set
        character.SetStats(player.BaseStats);
        
        player.BaseStats.CurrentHealth = player.BaseStats.MaxHealth;
        player.BaseStats.CurrentSkillPoints = player.BaseStats.MaxSkillPoints;

        _playerName.text = player.ScriptableCharacterName;
        _playerHealthText.text = "HP: " + player.BaseStats.MaxHealth;
        _playerSkillPointsText.text = "SP: " + player.BaseStats.MaxSkillPoints;
        _playerLevel.text = "Level " + player.BaseStats.Level;
        
        _playerSkillSubMenuOptionText.text = player.Skills[0].SkillAttributes.SkillName;
        _playerSkillSubMenuOptionCost.text = player.Skills[0].SkillAttributes.SkillCost.ToString();
    }

    public void SetHealthText(string healthText) {
        _playerHealthText.text = healthText;
    }

    public void SetSkillPointsText(string skillPointsText) {
        _playerSkillPointsText.text = skillPointsText;
    }

    public void SetLevel(int level) {
        _playerLevel.text = "Level " + level;
    }

    #region old exp code

    // Note:
    // Might have an exp bar for later or current and exp for next level
    // public void SetExperienceRequiredForNextLevel() {

    // }

    // private void LevelSystem_onExperienceUpdate(object sender, System.EventArgs e) {
    //     throw new System.NotImplementedException();
    // }
    #endregion
}
