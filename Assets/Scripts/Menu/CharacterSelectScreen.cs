using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelectScreen : MenuScreen {
    // This script represents everything specific to the character selection screen

    [SerializeField] private ScriptablePlayer[] _characters;
    [SerializeField] private TMP_Text _characterText;
    [SerializeField] private SpriteRenderer _currentCharacterSpriteRenderer;
    private int _selectedCharacter;

    void Start() => _currentCharacterSpriteRenderer.sprite = _characters[_selectedCharacter].Sprite;

    public void SetCharacter() {
        PlayerPrefs.SetInt("selectedCharacter", _selectedCharacter);
        _characterText.text = "You have selected the " + _characters[_selectedCharacter].ScriptableCharacterName + "!";
    }

    public void NextCharacter() {
        _currentCharacterSpriteRenderer.enabled = false;
        _selectedCharacter = (_selectedCharacter + 1) % _characters.Length;
        _currentCharacterSpriteRenderer.enabled = true;
        _currentCharacterSpriteRenderer.sprite = _characters[_selectedCharacter].Sprite;
    }

    public void PreviousCharacter() {
        _currentCharacterSpriteRenderer.enabled = false;
        _selectedCharacter--;
        if (_selectedCharacter < 0 ) {
            _selectedCharacter += _characters.Length;
        }
        _currentCharacterSpriteRenderer.enabled = true;
        _currentCharacterSpriteRenderer.sprite = _characters[_selectedCharacter].Sprite;
    }
}
