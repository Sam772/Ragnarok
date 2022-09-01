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
            GameManager.SetState(new Won(GameManager));
        // } else {
            GameManager.SetState(new EnemyTurn(GameManager));
        // }
    }

    public override IEnumerator Defend() {
        //_gameHUD.Gamestatus.text = _player.CharacterName + " is defending!";

        //Debug.Log("Player DEF: " + _player.Stats.Defence);

        // should double player defence
        //_player.Defend();
        //Debug.Log("Player DEF: " + _player.Stats.Defence);

        //ChangeState(GameState.EnemyTurn);

        yield return new WaitForSeconds(1.5f);

        // ensure player defence is always what it originally is after enemy attacks
        //StartCoroutine(_player.ReturnToOriginalDefence());
    }

    public override IEnumerator Skill() {
        // show the skill box
        // if (_playerSkillBox.activeSelf == false)  {
        //     _playerSkillBox.SetActive(true);
        // } else {
        //     _playerSkillBox.SetActive(false);
        // }

        // _gameHUD.Gamestatus.text = _player.CharacterName + " used " + _player.SkillOne.SkillName + "!";
        // State = GameState.EnemyTurn;

        // // temporary solution
        // switch(_player.CharacterName) {
        //     case "Knight":
        //     _player.SkillOne.BolsterDefence(_player, _playerHUD);
        //     break;

        //     case "Berserker":
        //     _player.SkillOne.Berserk(_player, _playerHUD);
        //     break;
        // }

        yield return new WaitForSeconds(1.5f);
    }
}
