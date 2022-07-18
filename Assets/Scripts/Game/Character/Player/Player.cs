using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    // This script represents a playable character which derives from a base character

    // Skill and leveling
    public int maxSkillPoints;
    public int currentSkillPoints;
    public Skill skillOne;
    public LevelSystem levelSystem;
    [SerializeField] private PlayerHUD playerHUD;

    private void Awake() {
        levelSystem = new LevelSystem();
        playerHUD.SetLevelSystem(levelSystem);
    }
}
