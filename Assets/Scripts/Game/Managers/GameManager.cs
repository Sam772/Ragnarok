using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : StaticInstanceGameManager<GameManager> {

    // This script manages the game while its running
    [Header("Managers")]
    [SerializeField] private BattleManager _battleManager;

    // Player, enemy, the ui and starting positions
    [Header("Player")]
    [SerializeField] private Player _player;
    public Player Player => _player;

    [SerializeField] private PlayerHUD _playerHUD;
    public PlayerHUD PlayerHUD => _playerHUD;

    // change into player input script
    [SerializeField] private GameObject _playerAttackButton;
    [SerializeField] private GameObject _playerSkillButton;
    [SerializeField] private GameObject _playerSkillBox;

    [Header("Enemy")]
    [SerializeField] private Enemy _enemy;
    public Enemy Enemy => _enemy;
    [SerializeField] private EnemyHUD _enemyHUD;
    public EnemyHUD EnemyHUD => _enemyHUD;
    
    [Header("Game")]
    [SerializeField] private GameHUD _gameHUD;
    public GameHUD GameHUD => _gameHUD;

    // List of playable characters
    [SerializeField] private Player[] _playableCharacters;

    void Start() => SetState(new Setup(this));

    public void OnAttack() {
        StartCoroutine(State.Attack());
    }

    public void OnSkill() {
        StartCoroutine(State.Skill());
    }

    public void OnDefend() {
        StartCoroutine(State.Defend());
    }
}