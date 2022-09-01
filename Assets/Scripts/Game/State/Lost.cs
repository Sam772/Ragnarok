using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : State {
    public Lost(GameManager gameManager) : base(gameManager) {

    }

    public override IEnumerator Start() {
        // _playerAttackButton.SetActive(false);
        // _gameHUD.MenuButton.SetActive(true);

        // if (GameState == GameState.Won) {
        //     _gameHUD.SetGameStatusText("You have won!");
        //     _playerHUD.LevelSystem.AddExperience(100);
        // } else
        //     _gameHUD.SetGameStatusText("You have lost!");
        // }
        yield break;
    }
}
