using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
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
