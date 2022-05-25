using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    private enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };
    private BattleState state;
    [SerializeField] private Player player;
    [SerializeField] private Transform playerStart;
    [SerializeField] private CharacterHUD playerHUD;
    [SerializeField] private Enemy enemy;
    [SerializeField] private CharacterHUD enemyHUD;
    [SerializeField] private Transform enemyStart;
    [SerializeField] private GameHUD gameHUD;
    [SerializeField] private GameObject attackButton;

    private void Start() {
        gameHUD.gamestatus.text = "Setting up battle!";
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    private IEnumerator SetupBattle() {
        Instantiate(player.gameObject, playerStart).GetComponent<Player>();
        Instantiate(enemy.gameObject, enemyStart).GetComponent<Enemy>();
        enemyHUD = FindObjectOfType<EnemyHUD>();
        playerHUD = FindObjectOfType<PlayerHUD>();
        player.currentHealth = player.maxHealth;
        enemy.currentHealth = enemy.maxHealth;

        yield return new WaitForSeconds(1.5f);

        state = BattleState.PLAYERTURN;
        gameHUD.gamestatus.text = "Choose an action!";
    }

    public void PlayerTurn() {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());   
    }

    private IEnumerator PlayerAttack() {
        gameHUD.gamestatus.text = "Player is attacking!";
        enemy.DealDamage(player.strength, enemy.defence);
        enemyHUD.healthText.text = enemy.currentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        if (enemy.CheckIfDead(enemy.gameObject)) {
            state = BattleState.WON;
            EndBattle();
        } else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyAttack());
        }
    }

    private IEnumerator EnemyAttack() {
        gameHUD.gamestatus.text = "Enemy is attacking!";
        player.DealDamage(enemy.strength, player.defence);
        playerHUD.healthText.text = player.currentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        if (player.CheckIfDead(player.gameObject)) {
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            gameHUD.gamestatus.text = "Choose an action!";
        }
    }

    private void EndBattle() {

        attackButton.SetActive(false);
        gameHUD.menuButton.SetActive(true);

        if (state == BattleState.WON)
            gameHUD.gamestatus.text = "You have won!";
        else
            gameHUD.gamestatus.text = "You have lost!";
    }
}
