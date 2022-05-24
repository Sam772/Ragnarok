using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };
    public BattleState state;
    public Player player;
    public Transform playerStart;
    [SerializeField] private CharacterHUD playerHUD;
    public Enemy enemy;
    [SerializeField] private CharacterHUD enemyHUD;
    public Transform enemyStart;
    [SerializeField] private GameHUD gameHUD;
    [SerializeField] private GameObject attackButton;

    private void Start() {
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
    }

    public void PlayerTurn() {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());   
    }

    private IEnumerator PlayerAttack() {
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
        player.DealDamage(enemy.strength, player.defence);
        playerHUD.healthText.text = player.currentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        if (player.CheckIfDead(player.gameObject)) {
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
        }
    }

    private void EndBattle() {

        attackButton.SetActive(false);

        if (state == BattleState.WON)
            gameHUD.gamestatus.text = "You have won!";
        else
            gameHUD.gamestatus.text = "You have lost!";
    }
}
