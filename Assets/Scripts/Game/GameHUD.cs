using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour {
    public TMP_Text gamestatus;
    [SerializeField] public TMP_Text skillName;
    [SerializeField] public TMP_Text skillCost;
    public GameObject menuButton;

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
