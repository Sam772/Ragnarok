using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHUD : CharacterHUD {
    // This scripts represents the enemy ui which derives from a base character ui
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private TMP_Text _enemyHealthText;
    public void InitialiseEnemy(Character character, ScriptableEnemy enemy) {
        base.Initalise(character);

        enemy.Prefab.SetStats(enemy.BaseStats);

        _enemyName.text = enemy.ScriptableCharacterName;
        _enemyHealthText.text = "HP: " + enemy.BaseStats.MaxHealth;
    }

    public void SetHealthText(string healthText) {
        _enemyHealthText.text = healthText;
    }
}
