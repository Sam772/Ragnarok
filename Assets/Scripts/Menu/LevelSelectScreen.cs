using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScreen : MenuScreen {
    // This script represents everything specific to the level selection screen

    public void ChangeToLevelOne() {
        SceneManager.LoadScene("LevelOne");
    }
}
