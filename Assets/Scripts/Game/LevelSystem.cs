using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem {
    // This script is for the leveling system
    
    // Leveling stuff
    private int _level;
    private int _currentExperience;
    private int _experienceToNextLevel;
    public event EventHandler OnLevelUpdate;

    // Note:
    // For potential exp bar
    // public event EventHandler onExperienceUpdate;

    public LevelSystem() {
        _level = 1;
        _currentExperience = 0;
        _experienceToNextLevel = 100;
    }

    public void AddExperience(int experienceGained) {
        _currentExperience += experienceGained;
        while (_currentExperience >= _experienceToNextLevel) {
            _level++;
            Debug.Log("Leveled up! - " + _level);
            _currentExperience -= _experienceToNextLevel;
            if (OnLevelUpdate != null) OnLevelUpdate(this, EventArgs.Empty);
        }

        //if (onExperienceUpdate != null) onExperienceUpdate(this, EventArgs.Empty);

    }

    public int GetLevel() {
        return _level;
    }
    
}
