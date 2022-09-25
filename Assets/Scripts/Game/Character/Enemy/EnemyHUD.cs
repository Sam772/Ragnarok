using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHUD : CharacterHUD {
    // This scripts represents the enemy ui which derives from a base character ui
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private TMP_Text _enemyHealthText;
    [SerializeField] private TMP_Text _enemyLevel;
    [SerializeField] private TMP_Text _enemySkillPointsText;

    public void InitialiseEnemy(Character character, ScriptableEnemy enemy) {
        base.Initalise(character);

        character.SetStats(enemy.BaseStats);

        enemy.BaseStats.CurrentHealth = enemy.BaseStats.MaxHealth;

        _enemyName.text = enemy.ScriptableCharacterName;
        _enemyHealthText.text = "HP: " + enemy.BaseStats.MaxHealth;
        _enemySkillPointsText.text = "SP: " + enemy.BaseStats.MaxSkillPoints;
        _enemyLevel.text = "Level: " + enemy.BaseStats.Level;
    }

    public void SetHealthText(string healthText) {
        _enemyHealthText.text = healthText;
    }

    public void SetSkillPointsText(string skillPointsText) {
        _enemySkillPointsText.text = skillPointsText;
    }
}
