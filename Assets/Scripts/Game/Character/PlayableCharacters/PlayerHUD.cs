using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : CharacterHUD {
    // This scripts represents the player ui which derives from a base character ui
    [SerializeField] private TMP_Text _playerLevel;
    public LevelSystem LevelSystem;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerHealthText;
    [SerializeField] private TMP_Text _playerSkillPointsText;

    public void InitalisePlayer(Character character, ScriptablePlayer player) {
        base.Initalise(character);

        player.Prefab.SetStats(player.BaseStats);
        
        _playerName.text = player.ScriptableCharacterName;
        _playerHealthText.text = "HP: " + player.BaseStats.MaxHealth;
        _playerSkillPointsText.text = "SP: " + player.BaseStats.MaxSkillPoints;
    }

    private void SetLevel(int level) {
        _playerLevel.text = "Level " + level;
    }

    public void SetLevelSystem(LevelSystem levelSystem) {
        this.LevelSystem = levelSystem;

        SetLevel(levelSystem.GetLevel());

        levelSystem.OnLevelUpdate += LevelSystem_onLevelUpdate;
    }

    private void LevelSystem_onLevelUpdate(object sender, System.EventArgs e) {
        SetLevel(LevelSystem.GetLevel());
    }

    public void SetHealthText(string healthText) {
        _playerHealthText.text = healthText;
    }

    public void SetSkillPointsText(string skillPointsText) {
        _playerSkillPointsText.text = skillPointsText;
    }


    // Note:
    // Might have a exp bar for later or current and exp for next level
    // public void SetExperienceRequiredForNextLevel() {

    // }

    // private void LevelSystem_onExperienceUpdate(object sender, System.EventArgs e) {
    //     throw new System.NotImplementedException();
    // }

}
