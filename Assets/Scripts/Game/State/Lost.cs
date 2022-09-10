using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : State {
    public Lost(GameManager gameManager) : base(gameManager) {

    }

    public override IEnumerator Start() {
        GameManager.GameHUD.PlayerAttackButton.SetActive(false);
        GameManager.GameHUD.MenuButton.SetActive(true);

        GameManager.GameHUD.SetGameStatusText("You have lost!");
        
        yield break;
    }
}
