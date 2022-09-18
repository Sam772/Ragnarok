using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : State {

    public Setup(GameManager gameManager) : base(gameManager) {

    }

    public override IEnumerator Start() {
        GameManager.GameHUD.SetGameStatusText("Setting up battle!");

        CharacterManager.Instance.SpawnCharacters();

        GameManager.GameHUD.Initalise(CharacterManager.Instance.Player, GameManager.Enemy);

        yield return new WaitForSeconds(1.5f);

        GameManager.SetState(new PlayerTurn(GameManager));
    }
}
