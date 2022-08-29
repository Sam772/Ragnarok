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
}

[Serializable]
public struct Stats {
    public int MaxHealth;
    public int CurrentHealth;
    public int Strength;
    public int Defence;
}

[Serializable]
public enum Faction {
    Player = 0,
    Enemy = 1
}