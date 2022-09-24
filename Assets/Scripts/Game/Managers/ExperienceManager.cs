using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : StaticInstance<ExperienceManager> {

    private int _level;
    private int _currentExperience;
    private int _experienceToNextLevel;
    public event EventHandler OnLevelUpdate;
    private ScriptablePlayer _player => CharacterManager.Instance.PlayableCharacterScriptable;

    // For potential exp bar
    // public event EventHandler onExperienceUpdate;

    public void GetExperienceData() {
        var playerStats = _player.BaseStats;

        _level = playerStats.Level;
        _currentExperience = playerStats.CurrentExperience;
        _experienceToNextLevel = 100 * _level * 2;

        Debug.Log("Level: " + playerStats.Level + " XP: " + playerStats.CurrentExperience);
    }

    public void AddExperience(int experienceGained) {
        var playerStats = _player.BaseStats;

        _currentExperience += experienceGained;
        while (_currentExperience >= _experienceToNextLevel) {
            _level++;
            Debug.Log("Leveled up! - " + _level);

            SetNewStats();
            _currentExperience -= _experienceToNextLevel;

            if (OnLevelUpdate != null) OnLevelUpdate(this, EventArgs.Empty);
        }

        playerStats.Level = _level;
        playerStats.CurrentExperience = _currentExperience;

        _player.Prefab.SetStats(playerStats);

        GameManager.Instance.GameHUD.PlayerHUD.SetLevel(_level);
        GameManager.Instance.GameHUD.SetGameStatusText("Leveled up!");
        
        Debug.Log("Level: " + playerStats.Level + " XP: " + playerStats.CurrentExperience);
        
        //if (onExperienceUpdate != null) onExperienceUpdate(this, EventArgs.Empty);
    }

    public void SetNewStats() {
        _player.Prefab.SetNewStats(_player);
    }
}