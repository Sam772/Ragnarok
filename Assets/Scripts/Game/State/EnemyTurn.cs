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

        GameManager.Player.TakeDamage(player, enemy);

        yield return new WaitForSeconds(1.5f);

        GameManager.GameHUD.PlayerAttackButton.SetActive(true);
        GameManager.GameHUD.PlayerDefendButton.SetActive(true);

        if (GameManager.Player.CheckIfDead(GameManager.Player)) {
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

        GameManager.GameHUD.PlayerAttackButton.SetActive(true);
        GameManager.GameHUD.PlayerDefendButton.SetActive(true);

        GameManager.SetState(new PlayerTurn(GameManager));
    }

    public override IEnumerator Skill() {
        return base.Skill();
    }
}
