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
    [SerializeField] private BattleManager _battleManager;
    public GameState State { get; private set; }

    // Player, enemy, the ui and starting positions
    [Header("Player")]
    //[SerializeField] private Player _player;
    [SerializeField] private PlayerHUD _playerHUD;
    private Player _spawnedPlayer;

    // change into player input script
    [SerializeField] private GameObject _playerAttackButton;
    [SerializeField] private GameObject _playerSkillButton;
    [SerializeField] private GameObject _playerSkillBox;

    [Header("Enemy")]
    //[SerializeField] private Enemy _enemy;
    [SerializeField] private CharacterHUD _enemyHUD;
    private Enemy _spawnedEnemy;
    

    [Header("Game")]
    [SerializeField] private GameHUD _gameHUD;

    // List of playable characters
    [SerializeField] private Player[] _playableCharacters;

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

        _gameHUD.SetGameStatusText("Setting up battle!");

        CharacterManager.Instance.SpawnCharacters();

        SetupBattleUI();
        //SetupPlayerSkills();

        yield return new WaitForSeconds(1.5f);

        SetPlayerTurn();
        ChangeState(GameState.PlayerTurn);
    }



    private void SetupBattleUI() {

        //_gameHUD.SkillName.text = _player.SkillOne.SkillName.ToString();
        //_gameHUD.SkillCost.text = _player.SkillOne.SkillCost.ToString();

        //_playerHUD = _spawnedPlayer.PlayerHUD;
        //_enemyHUD = _spawnedEnemy.EnemyHUD;

        //var playerStats = _player.Stats;
        //var enemyStats = _enemy.Stats;

        //playerStats.CurrentHealth = playerStats.MaxHealth;
        //_player.SetStats(playerStats);

        //enemyStats.CurrentHealth = enemyStats.MaxHealth;
        //_enemy.SetStats(enemyStats);

        //_player.CurrentSkillPoints = _player.MaxSkillPoints;
        //_playerHUD.CharacterSkillPoints.text = "SP: " + _player.MaxSkillPoints.ToString();
    }

    private void SetupPlayerSkills() {
        // to reset stats properly if skills were used
        // temporary solution

        // if (_player.CharacterName == "Knight") {
        //     var knightStats = _player.Stats;
        //     knightStats.Defence = 3;
        //     _player.SetStats(knightStats);
        // }
        // if (_player.CharacterName == "Berserker") {
        //     var berserkStats = _player.Stats;
        //     berserkStats.Strength = 7;
        //     _player.SetStats(berserkStats);
        // }
    }

    private void SetPlayerTurn() {
        _gameHUD.SetGameStatusText("Choose an action!");
    }

    public void OnAttack() {
        if (State != GameState.PlayerTurn) return;

        StartCoroutine(PlayerAttackCoroutine());
    }

    private IEnumerator PlayerAttackCoroutine() {
        //_gameHUD.Gamestatus.text = _player.CharacterName + " is attacking!";

        // called on the enemy, subtracting its health
        //_enemy.TakeDamage(_player.Stats.Strength, _enemy.Stats.Defence);
        //battleManager.Attack();

        //_enemyHUD.HealthText.text = "HP: " + _enemy.Stats.CurrentHealth.ToString();
        State = GameState.EnemyTurn;

        yield return new WaitForSeconds(1.5f);

        // if (_enemy.CheckIfDead(_enemy.gameObject)) {
        //     ChangeState(GameState.Won);
        // } else {
        //     ChangeState(GameState.EnemyTurn);
        // }
    }

    public IEnumerator PlayerDefendCoroutine() {
        //_gameHUD.Gamestatus.text = _player.CharacterName + " is defending!";

        //Debug.Log("Player DEF: " + _player.Stats.Defence);

        // should double player defence
        //_player.Defend();
        //Debug.Log("Player DEF: " + _player.Stats.Defence);

        ChangeState(GameState.EnemyTurn);

        yield return new WaitForSeconds(1.5f);

        // ensure player defence is always what it originally is after enemy attacks
        //StartCoroutine(_player.ReturnToOriginalDefence());
    }

    private void EnemyTurn() {
        if (State != GameState.EnemyTurn) return;

        // ai moment
        // if (_enemy.Stats.CurrentHealth <= 5) {
        //     StartCoroutine(EnemyDefendCoroutine());
        // } else {
        //     StartCoroutine(EnemyAttackCoroutine());
        // }
    }

    private IEnumerator EnemyAttackCoroutine() {
        //_gameHUD.Gamestatus.text = _enemy.CharacterName + " is attacking!";
        //_player.TakeDamage(_enemy.Stats.Strength, _player.Stats.Defence);
        //_playerHUD.HealthText.text = "HP: " + _player.Stats.CurrentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        // if (_player.CheckIfDead(_player.gameObject)) {
        //     ChangeState(GameState.Lost);
        // } else {
        //     ChangeState(GameState.PlayerTurn);
        //     SetPlayerTurn();
        // }
    }

    private IEnumerator EnemyDefendCoroutine() {
        // _gameHUD.Gamestatus.text = _enemy.CharacterName + " is defending!";

        // Debug.Log("Enemy DEF: " + _enemy.Stats.Defence);

        // // should double enemy defence
        // _enemy.Defend();
        // Debug.Log("Enemy DEF: " + _enemy.Stats.Defence);

        yield return new WaitForSeconds(1.5f);

        // ensure enemy defence is always what it originally is after enemy attacks
        // StartCoroutine(_enemy.ReturnToOriginalDefence());

        // Debug.Log("Enemy DEF: " + _enemy.Stats.Defence);

        // ChangeState(GameState.PlayerTurn);
    }

    public void OnSkill() {
        if (State != GameState.PlayerTurn) return;

        // show the skill box
        if (_playerSkillBox.activeSelf == false)  {
            _playerSkillBox.SetActive(true);
        } else {
            _playerSkillBox.SetActive(false);
        }
    }

    public void PlayerSkillOne() {
        if (State != GameState.PlayerTurn) return;
        
        StartCoroutine(PlayerSkillOneCoroutine());
    }

    public IEnumerator PlayerSkillOneCoroutine() {
        // _gameHUD.Gamestatus.text = _player.CharacterName + " used " + _player.SkillOne.SkillName + "!";
        // State = GameState.EnemyTurn;

        // // temporary solution
        // switch(_player.CharacterName) {
        //     case "Knight":
        //     _player.SkillOne.BolsterDefence(_player, _playerHUD);
        //     break;

        //     case "Berserker":
        //     _player.SkillOne.Berserk(_player, _playerHUD);
        //     break;
        // }

        yield return new WaitForSeconds(1.5f);

        ChangeState(GameState.EnemyTurn);
    }

    public void OnDefend() {
        if (State != GameState.PlayerTurn) return;

        StartCoroutine(PlayerDefendCoroutine());
    }

    private void EndBattle() {

        _playerAttackButton.SetActive(false);
        _gameHUD.MenuButton.SetActive(true);

        if (State == GameState.Won) {
            _gameHUD.SetGameStatusText("You have won!");
            _playerHUD.LevelSystem.AddExperience(100);
        } else
            _gameHUD.SetGameStatusText("You have lost!");
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

    // private void SetupPlayerCharacterAndEnemy() {
    //     //[SerializeField] private Player _player;
    //     // private Player _spawnedPlayer;
    //     //int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
    //     //_player = _playableCharacters[selectedCharacter];

    //     //_spawnedPlayer = Instantiate(_player, _playerStartPosition);
    //     //_spawnedEnemy = Instantiate(_enemy, _enemyStartPosition);
    // }