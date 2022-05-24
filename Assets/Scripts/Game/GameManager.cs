using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };
    public BattleState state;
    public Player player;
    public Transform playerStart;
    public Enemy enemy;
    public Transform enemyStart;

    private void Start() {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    private IEnumerator SetupBattle() {
        Player playerObj = Instantiate(player.gameObject, playerStart).GetComponent<Player>();
        Enemy enemyObj = Instantiate(enemy.gameObject, enemyStart).GetComponent<Enemy>();

        yield return new WaitForSeconds(1.5f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public void PlayerTurn() {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());   
    }

    private IEnumerator PlayerAttack() {

        yield return new WaitForSeconds(1.5f);
    }
}
