using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class CharacterHUD : MonoBehaviour {
    // This scripts represents the base character ui used for both players and enemies

    public TMP_Text HealthText;
    [SerializeField] public TMP_Text CharacterName;
    [SerializeField] public Character Character;

    private void Awake() {
        CharacterName.text = Character.CharacterName;
        HealthText.text = "HP: " + Character.Stats.MaxHealth.ToString();
    }
}
