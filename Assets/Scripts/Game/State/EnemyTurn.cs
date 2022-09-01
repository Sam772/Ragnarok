using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : State {
    public EnemyTurn(GameManager gameManager) : base(gameManager) {

    }

    public override IEnumerator Start() {
        // ai moment
        // if (_enemy.Stats.CurrentHealth <= 5) {
        //     StartCoroutine(EnemyDefendCoroutine());
        // } else {
        //     StartCoroutine(EnemyAttackCoroutine());
        // }
        yield break;
    }

    public override IEnumerator Attack() {
        //_gameHUD.Gamestatus.text = _enemy.CharacterName + " is attacking!";
        //_player.TakeDamage(_enemy.Stats.Strength, _player.Stats.Defence);
        //_playerHUD.HealthText.text = "HP: " + _player.Stats.CurrentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        // if (_player.CheckIfDead(_player.gameObject)) {
        //     ChangeState(GameState.Lost);
        // } else {
        //     ChangeState(GameState.PlayerTurn);
        //     SetPlayerTurn();
        // }
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
