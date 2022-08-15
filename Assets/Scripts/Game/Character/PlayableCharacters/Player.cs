using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    // This script represents a playable character which derives from a base character

    // Skill and leveling
    public int maxSkillPoints;
    public int currentSkillPoints;

    // maybe make skill an array later
    public Skill skillOne;
    private LevelSystem levelSystem;
    [SerializeField] public PlayerHUD playerHUD;

    private void Awake() {
        levelSystem = new LevelSystem();
        playerHUD.SetLevelSystem(levelSystem);
        this.SetLevelSystem(levelSystem);
    }

    private void SetLevelSystem(LevelSystem levelSystem) {
        this.levelSystem = levelSystem;

        levelSystem.onLevelUpdate += LevelSystem_OnLevelUpdate;
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
