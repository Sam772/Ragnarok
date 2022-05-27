using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelectScreen : MenuScreen {
    [SerializeField] private Character[] characters;
    public int selectedCharacter;
    public TMP_Text characterText;

    public void SetCharacterKnight() {
        PlayerPrefs.SetInt("selectedCharacter", 0);
        characterText.text = "You have selected the Knight!";
        //Debug.Log(selectedCharacter);
    }

    public void SetCharacterBerserker() {
        selectedCharacter = 1;
        PlayerPrefs.SetInt("selectedCharacter", 1);
        characterText.text = "You have selected the Berserker!";
        //Debug.Log(selectedCharacter);
    }
}
