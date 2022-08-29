using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelectScreen : MenuScreen {
    // This script represents everything specific to the character selection screen

    [SerializeField] private Character[] _characters;
    public int SelectedCharacter;
    [SerializeField] private TMP_Text _characterText;

    public void SetCharacter() {
        PlayerPrefs.SetInt("selectedCharacter", SelectedCharacter);
        //_characterText.text = "You have selected the " + _characters[SelectedCharacter].CharacterName + "!";
    }

    public void NextCharacter() {
        _characters[SelectedCharacter].gameObject.SetActive(false);
        SelectedCharacter = (SelectedCharacter + 1) % _characters.Length;
        _characters[SelectedCharacter].gameObject.SetActive(true);
    }

    public void PreviousCharacter() {
        _characters[SelectedCharacter].gameObject.SetActive(false);
        SelectedCharacter--;
        if (SelectedCharacter < 0 ) {
            SelectedCharacter += _characters.Length;
        }
        _characters[SelectedCharacter].gameObject.SetActive(true);
    }
}
