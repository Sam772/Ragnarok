using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelectScreen : MenuScreen {
    // This script represents everything specific to the character selection screen

    [SerializeField] private ScriptablePlayer[] _characters;
    [SerializeField] private TMP_Text _characterText;
    [SerializeField] private SpriteRenderer currentCharacterSpriteRenderer;
    private int SelectedCharacter;

    void Start() => currentCharacterSpriteRenderer.sprite = _characters[SelectedCharacter].Sprite;

    public void SetCharacter() {
        PlayerPrefs.SetInt("selectedCharacter", SelectedCharacter);
        _characterText.text = "You have selected the " + _characters[SelectedCharacter].ScriptableCharacterName + "!";
    }

    public void NextCharacter() {
        currentCharacterSpriteRenderer.enabled = false;
        SelectedCharacter = (SelectedCharacter + 1) % _characters.Length;
        currentCharacterSpriteRenderer.enabled = true;
        currentCharacterSpriteRenderer.sprite = _characters[SelectedCharacter].Sprite;
    }

    public void PreviousCharacter() {
        currentCharacterSpriteRenderer.enabled = false;
        SelectedCharacter--;
        if (SelectedCharacter < 0 ) {
            SelectedCharacter += _characters.Length;
        }
        currentCharacterSpriteRenderer.enabled = true;
        currentCharacterSpriteRenderer.sprite = _characters[SelectedCharacter].Sprite;
    }
}
