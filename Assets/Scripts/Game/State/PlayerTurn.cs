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

        GameManager.GameHUD.PlayerAttackButton.SetActive(false);

        // called on the enemy, subtracting its health
        GameManager.Enemy.TakeDamage(player, enemy);

        yield return new WaitForSeconds(1.5f);

        if (GameManager.Enemy.CheckIfDead(GameManager.Enemy)) {
            GameManager.SetState(new Won(GameManager));
        } else {
            GameManager.SetState(new EnemyTurn(GameManager));
        }
    }

    public override IEnumerator Defend() {
        //issue: always referencing player
        var player = CharacterManager.Instance.PlayableCharacterScriptable;

        GameManager.GameHUD.SetGameStatusText(player.ScriptableCharacterName + " is defending!");

        //Debug.Log("Player DEF: " + player.BaseStats.Defence);

        GameManager.Player.Defend(player);

        GameManager.GameHUD.PlayerDefendButton.SetActive(false);

        //Debug.Log("Player DEF: " + player.BaseStats.Defence);

        yield return new WaitForSeconds(1.5f);

        GameManager.SetState(new EnemyTurn(GameManager));
    }

    public override IEnumerator Skill() {
        // show the skill box
        if (GameManager.GameHUD.PlayerSkillBox.activeSelf == false)  {
            GameManager.GameHUD.PlayerSkillBox.SetActive(true);
        } else {
            GameManager.GameHUD.PlayerSkillBox.SetActive(false);
        }

        var player = CharacterManager.Instance.PlayableCharacterScriptable;

        GameManager.GameHUD.SetGameStatusText(player.ScriptableCharacterName + " used " + "!");
        // player.Skills.SkillName

        // temporary solution
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
