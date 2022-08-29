using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : State {
    public PlayerTurn(GameManager gameManager) : base(gameManager) {

    }

    public override IEnumerator Start() {
        GameManager.GameHUD.SetGameStatusText("Choose an action!");
        yield break;
    }

    public override IEnumerator Attack() {
        var player = CharacterManager.Instance.PlayableCharacterScriptable;
        var enemy = CharacterManager.Instance.EnemyScriptable;

        GameManager.GameHUD.SetGameStatusText(player.ScriptableCharacterName + " is attacking!");

        // called on the enemy, subtracting its health
        GameManager.Enemy.TakeDamage(player.BaseStats.Strength, enemy.BaseStats.Defence);

        GameManager.EnemyHUD.SetHealthText("HP: " + enemy.BaseStats.CurrentHealth);

        yield return new WaitForSeconds(1.5f);

        // if (_enemy.CheckIfDead(_enemy.gameObject)) {
        //     ChangeState(GameState.Won);
        // } else {
        //     ChangeState(GameState.EnemyTurn);
        // }
        
        GameManager.SetState(new EnemyTurn(GameManager));
    }
}
