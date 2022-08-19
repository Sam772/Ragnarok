using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    // This script sets up all of the screens and how they are handled

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private FileSelectScreen _fileSelectScreen;
    [SerializeField] private MainMenuScreen _mainMenuScreen;
    [SerializeField] private CharacterSelectScreen _characterSelectScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private LevelSelectScreen _levelSelectScreen;
    private MenuScreen _currentScreen;

    private void Awake() {
        ShowStartScreen();
    }

    private void Start() {
        _startScreen.Setup(this);
        _fileSelectScreen.Setup(this);
        _levelSelectScreen.Setup(this);
        _mainMenuScreen.Setup(this);
        _characterSelectScreen.Setup(this);
        _settingsScreen.Setup(this);
    }

    public void ShowStartScreen() => ShowScreen(_startScreen);
    public void ShowFileSelectScreen() => ShowScreen(_fileSelectScreen);
    public void ShowLevelSelectScreen() => ShowScreen(_levelSelectScreen);
    public void ShowMainMenuScreen() => ShowScreen(_mainMenuScreen);
    public void ShowCharacterSelectScreen() => ShowScreen(_characterSelectScreen);
    public void ShowSettingsScreen() => ShowScreen(_settingsScreen);

    // make ienumerator with fade effect
    private void ShowScreen(MenuScreen screen) {
        if (_currentScreen == screen) return;

        if (screen != _startScreen) _startScreen.Hide();
        if (screen != _fileSelectScreen) _fileSelectScreen.Hide();
        if (screen != _mainMenuScreen) _mainMenuScreen.Hide();
        if (screen != _levelSelectScreen) _levelSelectScreen.Hide();
        if (screen != _characterSelectScreen) _characterSelectScreen.Hide();
        if (screen != _settingsScreen) _settingsScreen.Hide();

        screen.Show();
        _currentScreen = screen;
    }
}