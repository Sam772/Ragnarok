using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private FileSelectScreen fileSelectScreen;
    [SerializeField] private LevelSelectScreen levelSelectScreen;
    private MenuScreen currentScreen;

    private void Awake() {
        ShowStartScreen();
    }

    private void Start() {
        startScreen.Setup(this);
        fileSelectScreen.Setup(this);
        levelSelectScreen.Setup(this);
    }

    public void ShowStartScreen() => ShowScreen(startScreen);
    public void ShowFileSelectScreen() => ShowScreen(fileSelectScreen);
    public void ShowLevelSelectScreen() => ShowScreen(levelSelectScreen);

    // make ienumerator with fade effect
    private void ShowScreen(MenuScreen screen) {
        if (currentScreen == screen) return;

        if (screen != startScreen) startScreen.Hide();
        if (screen != fileSelectScreen) fileSelectScreen.Hide();
        if (screen != levelSelectScreen) levelSelectScreen.Hide();

        screen.Show();
        currentScreen = screen;
    }
}
