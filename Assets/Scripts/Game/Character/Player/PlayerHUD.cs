using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : CharacterHUD {
    [SerializeField] public TMP_Text characterSkillPoints;
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text playerLevel;

    private void Start() {
        characterName.text = player.characterName;
        healthText.text = "HP: " + player.maxHealth.ToString();
        characterSkillPoints.text = "SP: " + player.maxSkillPoints.ToString();
        // set level here
    }

}
