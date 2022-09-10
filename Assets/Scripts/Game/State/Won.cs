using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : State {
    public Won(GameManager gameManager) : base(gameManager) {
        
    }

    public override IEnumerator Start() {
        GameManager.GameHUD.PlayerAttackButton.SetActive(false);
        GameManager.GameHUD.MenuButton.SetActive(true);

        // currently broken
        // GameManager.PlayerHUD.LevelSystem.AddExperience(100);
        
        GameManager.GameHUD.SetGameStatusText("You have won!");
        yield break;
    }
}
