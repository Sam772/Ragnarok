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

        GameManager.GameHUD.RemovePlayerUI();

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

        CharacterManager.Instance.Player.Defend(player);

        GameManager.GameHUD.RemovePlayerUI();

        //Debug.Log("Player DEF: " + player.BaseStats.Defence);

        yield return new WaitForSeconds(1.5f);

        GameManager.SetState(new EnemyTurn(GameManager));
    }

    public override IEnumerator Skill() {
        var player = CharacterManager.Instance.PlayableCharacterScriptable;

        GameManager.GameHUD.SetGameStatusText(player.ScriptableCharacterName + " used " + player.Skills[0].SkillAttributes.SkillName + "!");
        
        // get skill name in better way
        // player.Skills.SkillName

        CharacterManager.Instance.Player.ActivateSkill(player);

        GameManager.GameHUD.RemovePlayerUI();

        yield return new WaitForSeconds(1.5f);

        GameManager.SetState(new EnemyTurn(GameManager));
    }

    public override IEnumerator SkillSubMenu() {
        // show the skill submenu
        if (GameManager.GameHUD.PlayerSkillSubMenu.activeSelf == false)  {
            GameManager.GameHUD.PlayerSkillSubMenu.SetActive(true);
        } else {
            GameManager.GameHUD.PlayerSkillSubMenu.SetActive(false);
        }

        yield break;
    }
}
