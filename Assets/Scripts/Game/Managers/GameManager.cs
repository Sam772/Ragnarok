using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : StaticInstanceGameManager<GameManager> {

    // This script manages the game while its running
    [Header("Player")]
    [SerializeField] private Player _player;
    public Player Player => _player;

    [Header("Enemy")]
    [SerializeField] private Enemy _enemy;
    public Enemy Enemy => _enemy;
    
    [Header("Game")]
    [SerializeField] private GameHUD _gameHUD;
    public GameHUD GameHUD => _gameHUD;

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