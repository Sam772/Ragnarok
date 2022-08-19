using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    // This script represents a playable character which derives from a base character

    // Skill and leveling
    public int MaxSkillPoints;
    public int CurrentSkillPoints;

    // maybe make skill an array later
    public Skill SkillOne;
    private LevelSystem _levelSystem;
    [SerializeField] public PlayerHUD PlayerHUD;

    private void Awake() {
        // _levelSystem = new LevelSystem();
        // PlayerHUD.SetLevelSystem(_levelSystem);
        // this.SetLevelSystem(_levelSystem);
    }

    private void SetLevelSystem(LevelSystem levelSystem) {
        this._levelSystem = levelSystem;

        levelSystem.OnLevelUpdate += LevelSystem_OnLevelUpdate;
    }

    private void LevelSystem_OnLevelUpdate(object sender, EventArgs e) {
        // Increase stats when player levels up
        SetNewStats();
        //Debug.Log(this.characterName + " leveled up!");
    }

    private void SetNewStats() {
        // For testing
        // Debug.Log("hp: " + this.maxHealth + " str: " + this.strength + " def: " + this.defence);
        // this.maxHealth += 5;
        // this.currentHealth = this.maxHealth;
        // this.strength += 2;
        // this.defence += 1;
        // Debug.Log("hp: " + this.maxHealth + " str: " + this.strength + " def: " + this.defence);
    }
}
