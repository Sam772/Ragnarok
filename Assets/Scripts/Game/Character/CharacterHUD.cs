using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class CharacterHUD : MonoBehaviour {
    public TMP_Text healthText;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private Character character;

    private void Awake() {
        characterName.text = character.characterName;
        healthText.text = "HP: " + character.maxHealth.ToString();
    }
}
