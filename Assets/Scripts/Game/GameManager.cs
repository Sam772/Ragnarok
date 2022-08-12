using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : StaticInstance<GameManager> {

    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    // This script manages the game while its running
    [Header("Managers")]
    [SerializeField] private BattleManager battleManager;

    // The states handled while the game is running
    [Serializable]
    public enum GameState { 
        START = 0,
        PLAYERTURN = 1,
        ENEMYTURN = 2,
        WON = 3, 
        LOST = 4 
    }
    public GameState State { get; private set; }

    // Player, enemy, the ui and starting positions
    [Header("Player")]
    [SerializeField] private Player player;
    [SerializeField] private Transform playerStartPosition;
    [SerializeField] private PlayerHUD playerHUD;
    [SerializeField] private GameObject playerAttackButton;
    [SerializeField] private GameObject playerSkillButton;
    [SerializeField] private GameObject playerSkillBox;

    [Header("Enemy")]
    [SerializeField] private Enemy enemy;
    [SerializeField] private CharacterHUD enemyHUD;
    [SerializeField] private Transform enemyStart;

    [Header("Game")]
    [SerializeField] private GameHUD gameHUD;

    // List of playable characters
    [SerializeField] private Player[] playableCharacters;

    void Start() => ChangeState(GameState.START);

    public void ChangeState(GameState newState) {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState) {
            case GameState.START:
                StartCoroutine(SetupBattleCoroutine());
                break;
            case GameState.PLAYERTURN:
                SetPlayerTurn();
                break;
            case GameState.ENEMYTURN:
                EnemyTurn();
                break;
            case GameState.WON:
                EndBattle();
                break;
            case GameState.LOST:
                EndBattle();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    private IEnumerator SetupBattleCoroutine() {
        SetupPlayerCharacterAndEnemy();
        SetupBattleUI();
        SetupPlayerSkills();

        yield return new WaitForSeconds(1.5f);

        SetPlayerTurn();
        ChangeState(GameState.PLAYERTURN);
    }

    private void SetupPlayerCharacterAndEnemy() {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        player = playableCharacters[selectedCharacter];

        Instantiate(player.gameObject, playerStartPosition).GetComponent<Player>().gameObject.SetActive(true);
        Instantiate(enemy.gameObject, enemyStart).GetComponent<Enemy>();
    }

    private void SetupBattleUI() {
        gameHUD.gamestatus.text = "Setting up battle!";
        gameHUD.skillName.text = player.skillOne.skillName.ToString();
        gameHUD.skillCost.text = player.skillOne.skillCost.ToString();

        enemyHUD = FindObjectOfType<EnemyHUD>();
        playerHUD = FindObjectOfType<PlayerHUD>();

        player.currentHealth = player.maxHealth;
        enemy.currentHealth = enemy.maxHealth;
        player.currentSkillPoints = player.maxSkillPoints;
        playerHUD.characterSkillPoints.text = "SP: " + player.maxSkillPoints.ToString();
    }

    private void SetupPlayerSkills() {
        // to reset stats properly if skills were used
        // temporary solution
        if (player.characterName == "Knight") player.defence = 3;
        if (player.characterName == "Berserker") player.strength = 7;
    }

    private void SetPlayerTurn() {
        gameHUD.gamestatus.text = "Choose an action!";
    }

    public void OnAttack() {
        if (State != GameState.PLAYERTURN) return;

        StartCoroutine(PlayerAttackCoroutine());
    }

    private IEnumerator PlayerAttackCoroutine() {
        gameHUD.gamestatus.text = player.characterName + " is attacking!";

        // called on the enemy, subtracting its health
        enemy.Attack(player.strength, enemy.defence);
        //battleManager.Attack();

        enemyHUD.healthText.text = "HP: " + enemy.currentHealth.ToString();
        State = GameState.ENEMYTURN;

        yield return new WaitForSeconds(1.5f);

        if (enemy.CheckIfDead(enemy.gameObject)) {
            ChangeState(GameState.WON);
        } else {
            ChangeState(GameState.ENEMYTURN);
        }
    }

    public IEnumerator PlayerDefendCoroutine() {
        gameHUD.gamestatus.text = player.characterName + " is defending!";

        Debug.Log("Player DEF: " + player.defence);

        // should double player defence
        player.Defend();
        Debug.Log("Player DEF: " + player.defence);

        ChangeState(GameState.ENEMYTURN);

        yield return new WaitForSeconds(1.5f);

        // ensure player defence is always what it originally is after enemy attacks
        StartCoroutine(player.ReturnToOriginalDefence());
    }

    private void EnemyTurn() {
        if (State != GameState.ENEMYTURN) return;

        // ai moment
        if (enemy.currentHealth <= 5) {
            StartCoroutine(EnemyDefendCoroutine());
        } else {
            StartCoroutine(EnemyAttackCoroutine());
        }
    }

    private IEnumerator EnemyAttackCoroutine() {
        gameHUD.gamestatus.text = enemy.characterName + " is attacking!";
        player.Attack(enemy.strength, player.defence);
        playerHUD.healthText.text = "HP: " + player.currentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        if (player.CheckIfDead(player.gameObject)) {
            ChangeState(GameState.LOST);
        } else {
            ChangeState(GameState.PLAYERTURN);
            SetPlayerTurn();
        }
    }

    private IEnumerator EnemyDefendCoroutine() {
        gameHUD.gamestatus.text = enemy.characterName + " is defending!";

        Debug.Log("Enemy DEF: " + enemy.defence);

        // should double enemy defence
        enemy.Defend();
        Debug.Log("Enemy DEF: " + enemy.defence);

        yield return new WaitForSeconds(1.5f);

        // ensure enemy defence is always what it originally is after enemy attacks
        StartCoroutine(enemy.ReturnToOriginalDefence());

        Debug.Log("Enemy DEF: " + enemy.defence);

        ChangeState(GameState.PLAYERTURN);
    }

    public void OnSkill() {
        if (State != GameState.PLAYERTURN) return;

        // show the skill box
        if (playerSkillBox.activeSelf == false)  {
            playerSkillBox.SetActive(true);
        } else {
            playerSkillBox.SetActive(false);
        }
    }

    public void PlayerSkillOne() {
        if (State != GameState.PLAYERTURN) return;
        
        StartCoroutine(PlayerSkillOneCoroutine());
    }

    public IEnumerator PlayerSkillOneCoroutine() {
        gameHUD.gamestatus.text = player.characterName + " used " + player.skillOne.skillName + "!";
        State = GameState.ENEMYTURN;

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

        ChangeState(GameState.ENEMYTURN);
    }

    public void OnDefend() {
        if (State != GameState.PLAYERTURN) return;

        StartCoroutine(PlayerDefendCoroutine());
    }

    private void EndBattle() {

        playerAttackButton.SetActive(false);
        gameHUD.menuButton.SetActive(true);

        if (State == GameState.WON) {
            gameHUD.gamestatus.text = "You have won!";
            playerHUD.levelSystem.AddExperience(100);
        } else
            gameHUD.gamestatus.text = "You have lost!";
    }
}
