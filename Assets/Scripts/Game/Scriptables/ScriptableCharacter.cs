using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableCharacter : ScriptableObject {
    public Faction Faction;
    [SerializeField] private string _characterName;
    public string ScriptableCharacterName => _characterName;
    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;
    public Character Prefab;
    public Sprite Sprite;
    public ScriptableSkill[] Skills;
}

[Serializable]
public class Stats {
    public int Level;
    public int MaxHealth;
    public int CurrentHealth;
    public int Strength;
    public int Defence;
    public int MaxSkillPoints;
    public int CurrentSkillPoints;
    public int CurrentExperience;
}

[Serializable]
public enum Faction {
    Player = 0,
    Enemy = 1
}