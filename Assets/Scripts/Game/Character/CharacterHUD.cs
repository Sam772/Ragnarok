using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class CharacterHUD : MonoBehaviour {
    public TMP_Text healthText;
    [SerializeField] private Character character;

    private void Awake() {
        healthText.text = character.maxHealth.ToString();
    }
}
