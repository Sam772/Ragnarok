using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MenuScreen {
    public void ChangeToGameScene() {
        SceneManager.LoadScene("Game");
    }
}
