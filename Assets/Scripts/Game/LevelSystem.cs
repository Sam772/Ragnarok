using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem {
    
    private int level;
    private int currentExperience;
    private int experienceToNextLevel;

    public LevelSystem() {
        level = 0;
        currentExperience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int experienceGained) {
        currentExperience += experienceGained;
        if (currentExperience >= experienceToNextLevel) {
            level++;
            Debug.Log("Leveled up!");
            currentExperience -= experienceToNextLevel;
        }
    }

    public int GetLevel() {
        return level;
    }
    
}
