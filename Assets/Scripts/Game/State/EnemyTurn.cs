using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : State {
    public EnemyTurn(GameManager gameManager) : base(gameManager) {

    }

    public override IEnumerator Start() {
        GameManager.GameHUD.SetGameStatusText("Enemy turn!");
        
        var enemy = CharacterManager.Instance.EnemyScriptable;

        yield return new WaitForSeconds(0.5f);

        // ai moment
        if (enemy.BaseStats.CurrentHealth <= 5) {
            GameManager.OnDefend();
        } else {
            GameManager.OnAttack();
        }
    }

    public override IEnumerator Attack() {
        var player = CharacterManager.Instance.PlayableCharacterScriptable;
        var enemy = CharacterManager.Instance.EnemyScriptable;

        GameManager.GameHUD.SetGameStatusText(enemy.ScriptableCharacterName + " is attacking!");

        GameManager.Player.TakeDamage(enemy.BaseStats.Strength, player.BaseStats.Defence);

        yield return new WaitForSeconds(1.5f);

        if (GameManager.Player.CheckIfDead(GameManager.Player)) {
            GameManager.SetState(new Lost(GameManager));
        } else {
            GameManager.SetState(new PlayerTurn(GameManager));
        }
    }

    public override IEnumerator Defend() {
        // _gameHUD.Gamestatus.text = _enemy.CharacterName + " is defending!";

        // Debug.Log("Enemy DEF: " + _enemy.Stats.Defence);

        // // should double enemy defence
        // _enemy.Defend();
        // Debug.Log("Enemy DEF: " + _enemy.Stats.Defence);

        yield return new WaitForSeconds(1.5f);

        // ensure enemy defence is always what it originally is after enemy attacks
        // StartCoroutine(_enemy.ReturnToOriginalDefence());

        // Debug.Log("Enemy DEF: " + _enemy.Stats.Defence);

        // ChangeState(GameState.PlayerTurn);
    }

    public override IEnumerator Skill() {
        return base.Skill();
    }
}
