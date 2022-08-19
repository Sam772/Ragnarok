using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour {
    // This script represents the game ui which isn't attached to a character or enemy

    [SerializeField] private TMP_Text _gamestatus;
    [SerializeField] public TMP_Text SkillName;
    [SerializeField] public TMP_Text SkillCost;
    public GameObject MenuButton;

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void SetGameStatusText(string text) {
        _gamestatus.text = text;
    }
}
