using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    // This script manages the battling
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    // The states depending on what action the player chooses
    private enum PlayerActionState { Attack, Defend, Skill };
    private PlayerActionState _playerActionState;

    // Currently unused
    // The states depending on what action the enemy chooses
    private enum EnemyActionState { ATTACK, DEFEND };
    private EnemyActionState _enemyActionState;

    public void Attack() {
        
    }
}
