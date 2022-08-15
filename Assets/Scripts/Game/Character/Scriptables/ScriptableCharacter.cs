using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableCharacter : ScriptableObject {
    public Faction Faction;
    [SerializeField] private Stats stats;
    public Stats BaseStats => stats;
    public Character Prefab;
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