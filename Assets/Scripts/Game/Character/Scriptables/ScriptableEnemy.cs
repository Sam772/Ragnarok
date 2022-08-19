using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Enemy Character")]
public class ScriptableEnemy : ScriptableCharacter {
    public Enemies Enemies;
}

[Serializable]
public enum Enemies {
    Goblin = 0,
    Rat = 1
}
