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
    public GameState State { get; private set; }

    // Player, enemy, the ui and starting positions
    [Header("Player")]
    [SerializeField] private Player player;
    [SerializeField] private Transform playerStartPosition;
    [SerializeField] private PlayerHUD playerHUD;
    private Player _spawnedPlayer;

    // change into player input script
    [SerializeField] private GameObject playerAttackButton;
    [SerializeField] private GameObject playerSkillButton;
    [SerializeField] private GameObject playerSkillBox;

    [Header("Enemy")]
    [SerializeField] private Enemy enemy;
    [SerializeField] private CharacterHUD enemyHUD;
    [SerializeField] private Transform enemyStart;
    private Enemy _spawnedEnemy;
    

    [Header("Game")]
    [SerializeField] private GameHUD gameHUD;

    // List of playable characters
    [SerializeField] private Player[] playableCharacters;

    void Start() => ChangeState(GameState.Start);

    public void ChangeState(GameState newState) {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState) {
            case GameState.Start:
                StartCoroutine(SetupBattleCoroutine());
                break;
            case GameState.PlayerTurn:
                SetPlayerTurn();
                break;
            case GameState.EnemyTurn:
                EnemyTurn();
                break;
            case GameState.Won:
                EndBattle();
                break;
            case GameState.Lost:
                EndBattle();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);
        
        print($"New state: {newState}");
    }

    private IEnumerator SetupBattleCoroutine() {
        SetupPlayerCharacterAndEnemy();
        SetupBattleUI();
        SetupPlayerSkills();

        yield return new WaitForSeconds(1.5f);

        SetPlayerTurn();
        ChangeState(GameState.PlayerTurn);
    }

    private void SetupPlayerCharacterAndEnemy() {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        player = playableCharacters[selectedCharacter];

        _spawnedPlayer = Instantiate(player);
        _spawnedEnemy = Instantiate(enemy);
    }

    private void SetupBattleUI() {
        gameHUD.gamestatus.text = "Setting up battle!";

        CharacterManager.Instance.SpawnCharacters();

        gameHUD.skillName.text = player.skillOne.skillName.ToString();
        gameHUD.skillCost.text = player.skillOne.skillCost.ToString();

        playerHUD = _spawnedPlayer.playerHUD;
        enemyHUD = _spawnedEnemy.enemyHUD;

        var playerStats = player.Stats;
        var enemyStats = enemy.Stats;

        playerStats.CurrentHealth = playerStats.MaxHealth;
        player.SetStats(playerStats);

        enemyStats.CurrentHealth = enemyStats.MaxHealth;
        enemy.SetStats(enemyStats);

        player.currentSkillPoints = player.maxSkillPoints;
        playerHUD.characterSkillPoints.text = "SP: " + player.maxSkillPoints.ToString();
    }

    private void SetupPlayerSkills() {
        // to reset stats properly if skills were used
        // temporary solution

        if (player.characterName == "Knight") {
            var knightStats = player.Stats;
            knightStats.Defence = 3;
            player.SetStats(knightStats);
        }
        if (player.characterName == "Berserker") {
            var berserkStats = player.Stats;
            berserkStats.Strength = 7;
            player.SetStats(berserkStats);
        }
    }

    private void SetPlayerTurn() {
        gameHUD.gamestatus.text = "Choose an action!";
    }

    public void OnAttack() {
        if (State != GameState.PlayerTurn) return;

        StartCoroutine(PlayerAttackCoroutine());
    }

    private IEnumerator PlayerAttackCoroutine() {
        gameHUD.gamestatus.text = player.characterName + " is attacking!";

        // called on the enemy, subtracting its health
        enemy.TakeDamage(player.Stats.Strength, enemy.Stats.Defence);
        //battleManager.Attack();

        enemyHUD.healthText.text = "HP: " + enemy.Stats.CurrentHealth.ToString();
        State = GameState.EnemyTurn;

        yield return new WaitForSeconds(1.5f);

        if (enemy.CheckIfDead(enemy.gameObject)) {
            ChangeState(GameState.Won);
        } else {
            ChangeState(GameState.EnemyTurn);
        }
    }

    public IEnumerator PlayerDefendCoroutine() {
        gameHUD.gamestatus.text = player.characterName + " is defending!";

        Debug.Log("Player DEF: " + player.Stats.Defence);

        // should double player defence
        player.Defend();
        Debug.Log("Player DEF: " + player.Stats.Defence);

        ChangeState(GameState.EnemyTurn);

        yield return new WaitForSeconds(1.5f);

        // ensure player defence is always what it originally is after enemy attacks
        StartCoroutine(player.ReturnToOriginalDefence());
    }

    private void EnemyTurn() {
        if (State != GameState.EnemyTurn) return;

        // ai moment
        if (enemy.Stats.CurrentHealth <= 5) {
            StartCoroutine(EnemyDefendCoroutine());
        } else {
            StartCoroutine(EnemyAttackCoroutine());
        }
    }

    private IEnumerator EnemyAttackCoroutine() {
        gameHUD.gamestatus.text = enemy.characterName + " is attacking!";
        player.TakeDamage(enemy.Stats.Strength, player.Stats.Defence);
        playerHUD.healthText.text = "HP: " + player.Stats.CurrentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        if (player.CheckIfDead(player.gameObject)) {
            ChangeState(GameState.Lost);
        } else {
            ChangeState(GameState.PlayerTurn);
            SetPlayerTurn();
        }
    }

    private IEnumerator EnemyDefendCoroutine() {
        gameHUD.gamestatus.text = enemy.characterName + " is defending!";

        Debug.Log("Enemy DEF: " + enemy.Stats.Defence);

        // should double enemy defence
        enemy.Defend();
        Debug.Log("Enemy DEF: " + enemy.Stats.Defence);

        yield return new WaitForSeconds(1.5f);

        // ensure enemy defence is always what it originally is after enemy attacks
        StartCoroutine(enemy.ReturnToOriginalDefence());

        Debug.Log("Enemy DEF: " + enemy.Stats.Defence);

        ChangeState(GameState.PlayerTurn);
    }

    public void OnSkill() {
        if (State != GameState.PlayerTurn) return;

        // show the skill box
        if (playerSkillBox.activeSelf == false)  {
            playerSkillBox.SetActive(true);
        } else {
            playerSkillBox.SetActive(false);
        }
    }

    public void PlayerSkillOne() {
        if (State != GameState.PlayerTurn) return;
        
        StartCoroutine(PlayerSkillOneCoroutine());
    }

    public IEnumerator PlayerSkillOneCoroutine() {
        gameHUD.gamestatus.text = player.characterName + " used " + player.skillOne.skillName + "!";
        State = GameState.EnemyTurn;

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

        ChangeState(GameState.EnemyTurn);
    }

    public void OnDefend() {
        if (State != GameState.PlayerTurn) return;

        StartCoroutine(PlayerDefendCoroutine());
    }

    private void EndBattle() {

        playerAttackButton.SetActive(false);
        gameHUD.menuButton.SetActive(true);

        if (State == GameState.Won) {
            gameHUD.gamestatus.text = "You have won!";
            playerHUD.levelSystem.AddExperience(100);
        } else
            gameHUD.gamestatus.text = "You have lost!";
    }
}

// The states handled while the game is running
[Serializable]
public enum GameState { 
    Start = 0,
    PlayerTurn = 1,
    EnemyTurn = 2,
    Won = 3, 
    Lost = 4 
}