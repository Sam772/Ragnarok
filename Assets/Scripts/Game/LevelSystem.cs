using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem {
    
    private int level;
    private int currentExperience;
    private int experienceToNextLevel;
    public event EventHandler onLevelUpdate;

    // Note:
    // For potential exp bar
    // public event EventHandler onExperienceUpdate;

    public LevelSystem() {
        level = 1;
        currentExperience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int experienceGained) {
        currentExperience += experienceGained;
        if (currentExperience >= experienceToNextLevel) {
            level++;
            Debug.Log("Leveled up! - " + level);
            currentExperience -= experienceToNextLevel;
            if (onLevelUpdate != null) onLevelUpdate(this, EventArgs.Empty);
        }

        //if (onExperienceUpdate != null) onExperienceUpdate(this, EventArgs.Empty);

    }

    public int GetLevel() {
        return level;
    }
    
}
