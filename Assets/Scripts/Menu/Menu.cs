using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private MainScreen menuScreen;
    private MenuScreen currentScreen;

    private void Awake() {
        ShowStartScreen();
    }

    private void Start() {
        startScreen.Setup(this);
        menuScreen.Setup(this);
    }

    public void ShowStartScreen() => ShowScreen(startScreen);
    public void ShowMenuScreen() => ShowScreen(menuScreen);

    private void ShowScreen(MenuScreen screen) {
        if (currentScreen == screen) return;

        if (screen != startScreen) startScreen.Hide();
        if (screen != menuScreen) menuScreen.Hide();

        screen.Show();
        currentScreen = screen;
    }
}
