using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScreen : MenuScreen {
    public void ChangeToLevelOne() {
        SceneManager.LoadScene("LevelOne");
    }
}
