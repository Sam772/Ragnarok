using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    // This script manages the game while its running

    // The states handled while the game is running
    private enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };
    private BattleState state;

    // Player, enemy, the ui and starting positions
    [SerializeField] private Player player;
    [SerializeField] private Transform playerStart;
    [SerializeField] private PlayerHUD playerHUD;
    [SerializeField] private Enemy enemy;
    [SerializeField] private CharacterHUD enemyHUD;
    [SerializeField] private Transform enemyStart;
    [SerializeField] private GameHUD gameHUD;
    [SerializeField] private GameObject attackButton;
    [SerializeField] private GameObject skillButton;
    [SerializeField] private GameObject skillBox;

    // List of playable characters
    [SerializeField] private Player[] characters;

    private void Start() {
        gameHUD.gamestatus.text = "Setting up battle!";
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    private IEnumerator SetupBattle() {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        player = characters[selectedCharacter];
        gameHUD.skillName.text = player.skillOne.skillName.ToString();
        gameHUD.skillCost.text = player.skillOne.skillCost.ToString();
        Instantiate(player.gameObject, playerStart).GetComponent<Player>().gameObject.SetActive(true);
        Instantiate(enemy.gameObject, enemyStart).GetComponent<Enemy>();
        enemyHUD = FindObjectOfType<EnemyHUD>();
        playerHUD = FindObjectOfType<PlayerHUD>();
        player.currentHealth = player.maxHealth;
        enemy.currentHealth = enemy.maxHealth;
        player.currentSkillPoints = player.maxSkillPoints;
        playerHUD.characterSkillPoints.text = "SP: " + player.maxSkillPoints.ToString();

        // temporary solution
        if (player.characterName == "Knight") player.defence = 3;
        if (player.characterName == "Berserker") player.strength = 7;

        yield return new WaitForSeconds(1.5f);

        state = BattleState.PLAYERTURN;
        gameHUD.gamestatus.text = "Choose an action!";
    }

    public void OnAttack() {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());
    }

    private IEnumerator PlayerAttack() {
        gameHUD.gamestatus.text = player.characterName + " is attacking!";

        // called on the enemy, subtracting its health
        enemy.Attack(player.strength, enemy.defence);

        enemyHUD.healthText.text = "HP: " + enemy.currentHealth.ToString();
        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(1.5f);

        if (enemy.CheckIfDead(enemy.gameObject)) {
            state = BattleState.WON;
            EndBattle();
        } else {
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }
    }

    public IEnumerator PlayerDefend() {
        gameHUD.gamestatus.text = player.characterName + " is defending!";

        Debug.Log("Player DEF: " + player.defence);

        // should double player defence
        player.Defend();
        Debug.Log("Player DEF: " + player.defence);

        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(1.5f);

        EnemyTurn();

        // ensure player defence is always what it originally is after enemy attacks
        StartCoroutine(player.ReturnToOriginalDefence());
    }

    private void EnemyTurn() {
        if (state != BattleState.ENEMYTURN) return;

        // ai moment
        if (enemy.currentHealth <= 5) {
            StartCoroutine(EnemyDefend());
        } else {
            StartCoroutine(EnemyAttack());
        }
    }

    private IEnumerator EnemyAttack() {
        gameHUD.gamestatus.text = enemy.characterName + " is attacking!";
        player.Attack(enemy.strength, player.defence);
        playerHUD.healthText.text = "HP: " + player.currentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        if (player.CheckIfDead(player.gameObject)) {
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            gameHUD.gamestatus.text = "Choose an action!";
        }
    }

    private IEnumerator EnemyDefend() {
        gameHUD.gamestatus.text = enemy.characterName + " is defending!";

        Debug.Log("Enemy DEF: " + enemy.defence);

        // should double enemy defence
        enemy.Defend();
        Debug.Log("Enemy DEF: " + enemy.defence);

        yield return new WaitForSeconds(1.5f);

        // ensure enemy defence is always what it originally is after enemy attacks
        StartCoroutine(enemy.ReturnToOriginalDefence());

        Debug.Log("Enemy DEF: " + enemy.defence);

        state = BattleState.PLAYERTURN;
        gameHUD.gamestatus.text = "Choose an action!";
    }

    public void OnSkill() {
        if (state != BattleState.PLAYERTURN) return;

        // show the skill box
        if (skillBox.activeSelf == false)  {
            skillBox.SetActive(true);
        } else {
            skillBox.SetActive(false);
        }
    }

    public void PlayerSkillOne() {
        if (state != BattleState.PLAYERTURN) return;
        
        StartCoroutine(PlayerSkillOneActivate());
    }

    public IEnumerator PlayerSkillOneActivate() {
        gameHUD.gamestatus.text = player.characterName + " used " + player.skillOne.skillName + "!";
        state = BattleState.ENEMYTURN;

        // temporary solution
        switch(player.characterName) {
            case "Knight":
            player.skillOne.BolsterDefence(player, playerHUD);
            break;

            case "Berserker":
            player.skillOne.Berserk(player, playerHUD);
            break;
        }

        yield return new WaitForSeconds(1.5f);

        state = BattleState.ENEMYTURN;
        EnemyTurn();
    }

    public void OnDefend() {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerDefend());
    }

    private void EndBattle() {

        attackButton.SetActive(false);
        gameHUD.menuButton.SetActive(true);

        if (state == BattleState.WON) {
            gameHUD.gamestatus.text = "You have won!";
            playerHUD.levelSystem.AddExperience(100);
        } else
            gameHUD.gamestatus.text = "You have lost!";
    }
}
