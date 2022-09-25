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
            if (enemy.BaseStats.CurrentSkillPoints <= 2) {
                GameManager.OnAttack();
            } else {
                GameManager.OnSkill();
            }
        }
    }

    public override IEnumerator Attack() {
        var player = CharacterManager.Instance.PlayableCharacterScriptable;
        var enemy = CharacterManager.Instance.EnemyScriptable;

        GameManager.GameHUD.SetGameStatusText(enemy.ScriptableCharacterName + " is attacking!");

        CharacterManager.Instance.Player.TakeDamage(player, enemy);

        yield return new WaitForSeconds(1.5f);

        GameManager.GameHUD.ReinitialisePlayerUI();

        if (CharacterManager.Instance.Player.CheckIfDead(CharacterManager.Instance.Player)) {
            GameManager.SetState(new Lost(GameManager));
        } else {
            GameManager.SetState(new PlayerTurn(GameManager));
        }
    }

    public override IEnumerator Defend() {
        var enemy = CharacterManager.Instance.EnemyScriptable;

        GameManager.GameHUD.SetGameStatusText(enemy.ScriptableCharacterName + " is defending!");

        //Debug.Log("Player DEF: " + enemy.BaseStats.Defence);

        GameManager.Enemy.Defend(enemy);

        //Debug.Log("Player DEF: " + enemy.BaseStats.Defence);

        yield return new WaitForSeconds(1.5f);

        GameManager.GameHUD.ReinitialisePlayerUI();

        GameManager.SetState(new PlayerTurn(GameManager));
    }

    public override IEnumerator Skill() {
        var enemy = CharacterManager.Instance.EnemyScriptable;

        GameManager.GameHUD.SetGameStatusText(enemy.ScriptableCharacterName + " used " + enemy.Skills[0].SkillAttributes.SkillName + "!");

        GameManager.Enemy.ActivateSkill(enemy);

        yield return new WaitForSeconds(1.5f);

        GameManager.GameHUD.ReinitialisePlayerUI();

        if (CharacterManager.Instance.Player.CheckIfDead(CharacterManager.Instance.Player)) {
            GameManager.SetState(new Lost(GameManager));
        } else {
            GameManager.SetState(new PlayerTurn(GameManager));
        }
    }
}
