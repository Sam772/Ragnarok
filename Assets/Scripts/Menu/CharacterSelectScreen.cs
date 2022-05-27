using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelectScreen : MenuScreen {
    [SerializeField] private Character[] characters;
    public int selectedCharacter;
    [SerializeField] private TMP_Text characterText;

    public void SetCharacter() {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        characterText.text = "You have selected the " + characters[selectedCharacter].characterName + "!";
    }

    public void NextCharacter() {
        characters[selectedCharacter].gameObject.SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].gameObject.SetActive(true);
    }

    public void PreviousCharacter() {
        characters[selectedCharacter].gameObject.SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0 ) {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].gameObject.SetActive(true);
    }
}
