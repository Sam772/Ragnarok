using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour {
    public TMP_Text gamestatus;
    public GameObject menuButton;

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
