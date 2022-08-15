using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    // This script manages the battling
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    // The states depending on what action the player chooses
    private enum PlayerActionState { Attack, Defend, Skill };
    private PlayerActionState playerActionState;

    // Currently unused
    // The states depending on what action the enemy chooses
    private enum EnemyActionState { ATTACK, DEFEND };
    private EnemyActionState enemyActionState;

    public void Attack() {
        
    }
}
