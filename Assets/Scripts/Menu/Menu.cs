using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    // This script sets up all of the screens and how they are handled

    [SerializeField] private StartScreen startScreen;
    [SerializeField] private FileSelectScreen fileSelectScreen;
    [SerializeField] private LevelSelectScreen levelSelectScreen;
    [SerializeField] private MainMenuScreen mainMenuScreen;
    [SerializeField] private CharacterSelectScreen characterSelectScreen;
    [SerializeField] private SettingsScreen settingsScreen;
    private MenuScreen currentScreen;

    private void Awake() {
        ShowStartScreen();
    }

    private void Start() {
        startScreen.Setup(this);
        fileSelectScreen.Setup(this);
        levelSelectScreen.Setup(this);
        mainMenuScreen.Setup(this);
        characterSelectScreen.Setup(this);
        settingsScreen.Setup(this);
    }

    public void ShowStartScreen() => ShowScreen(startScreen);
    public void ShowFileSelectScreen() => ShowScreen(fileSelectScreen);
    public void ShowLevelSelectScreen() => ShowScreen(levelSelectScreen);
    public void ShowMainMenuScreen() => ShowScreen(mainMenuScreen);
    public void ShowCharacterSelectScreen() => ShowScreen(characterSelectScreen);
    public void ShowSettingsScreen() => ShowScreen(settingsScreen);

    // make ienumerator with fade effect
    private void ShowScreen(MenuScreen screen) {
        if (currentScreen == screen) return;

        if (screen != startScreen) startScreen.Hide();
        if (screen != fileSelectScreen) fileSelectScreen.Hide();
        if (screen != mainMenuScreen) mainMenuScreen.Hide();
        if (screen != levelSelectScreen) levelSelectScreen.Hide();
        if (screen != characterSelectScreen) characterSelectScreen.Hide();
        if (screen != settingsScreen) settingsScreen.Hide();

        screen.Show();
        currentScreen = screen;
    }
}