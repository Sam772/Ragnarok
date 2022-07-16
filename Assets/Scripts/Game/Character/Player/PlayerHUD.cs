using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : CharacterHUD {
    [SerializeField] public TMP_Text characterSkillPoints;
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text playerLevel;
    private LevelSystem levelSystem;

    private void Start() {
        characterName.text = player.characterName;
        healthText.text = "HP: " + player.maxHealth.ToString();
        characterSkillPoints.text = "SP: " + player.maxSkillPoints.ToString();
    }

    private void SetLevel(int level) {
        playerLevel.text = "Level " + level;
    }

    public void SetLevelSystem(LevelSystem levelSystem) {
        this.levelSystem = levelSystem;

        SetLevel(levelSystem.GetLevel());

        levelSystem.onLevelUpdate += LevelSystem_onLevelUpdate;
    }

    private void LevelSystem_onLevelUpdate(object sender, System.EventArgs e) {
        SetLevel(levelSystem.GetLevel());
    }


    // Note:
    // Might have a exp bar for later or current and exp for next level
    // public void SetExperienceRequiredForNextLevel() {

    // }

    // private void LevelSystem_onExperienceUpdate(object sender, System.EventArgs e) {
    //     throw new System.NotImplementedException();
    // }

}
