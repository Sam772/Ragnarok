using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class CharacterHUD : MonoBehaviour {
    // This scripts represents the base character ui used for both players and enemies
    private Character _character;
    public virtual void Initalise(Character character) {
        _character = character;
    }
}
