using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    // This script represents a playable character which derives from a base character
    private LevelSystem _levelSystem;

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

    public override void TakeDamage(ScriptablePlayer player, ScriptableEnemy enemy) {

        enemy.Prefab.CharacterAction = CharacterAction.Attacking;

        var playerStats = player.Prefab.Stats;
        var enemyStats = enemy.Prefab.Stats;

        int damage = enemyStats.Strength - playerStats.Defence;

        if (player.Prefab.CharacterAction == CharacterAction.Defending) {
            damage /= 2;
        }

        if (damage <= 0) { 
            damage = 1;
        }

        playerStats.CurrentHealth -= damage;

        //print("player health: " + playerStats.CurrentHealth);

        SetStats(playerStats);

        GameManager.Instance.GameHUD.PlayerHUD.SetHealthText("HP: " + playerStats.CurrentHealth.ToString());
    }

    public override void Defend(ScriptableCharacter player) {
        player.Prefab.CharacterAction = CharacterAction.Defending;
    }

    public void UseSkill(ScriptableCharacter player) {

    }
}
