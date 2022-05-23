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
        SetupBattle();
    }

    private void SetupBattle() {
        Player playerObj = Instantiate(player.gameObject, playerStart).GetComponent<Player>();
        Enemy enemyObj = Instantiate(enemy.gameObject, enemyStart).GetComponent<Enemy>();
    }
}
