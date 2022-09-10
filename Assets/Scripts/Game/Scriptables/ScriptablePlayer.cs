using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Playable Character")]
public class ScriptablePlayer : ScriptableCharacter {
    public PlayableCharacter PlayableCharacter;
}

[Serializable]
public enum PlayableCharacter {
    Knight = 0,
    Berserker = 1
}