using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : CharacterHUD {
    // This scripts represents the player ui which derives from a base character ui

    // Make this private and set the value here
    [SerializeField] public TMP_Text CharacterSkillPoints;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _playerLevel;
    public LevelSystem LevelSystem;

    private void Start() {
        CharacterName.text = _player.CharacterName;
        HealthText.text = "HP: " + _player.Stats.MaxHealth.ToString();
        CharacterSkillPoints.text = "SP: " + _player.MaxSkillPoints.ToString();
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


    // Note:
    // Might have a exp bar for later or current and exp for next level
    // public void SetExperienceRequiredForNextLevel() {

    // }

    // private void LevelSystem_onExperienceUpdate(object sender, System.EventArgs e) {
    //     throw new System.NotImplementedException();
    // }

}
