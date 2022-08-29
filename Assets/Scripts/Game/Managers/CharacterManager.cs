using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : StaticInstance<CharacterManager> {

    [Header("Spawn Positions")]
    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private Transform _enemySpawnPosition;
    [SerializeField] private PlayerHUD _playerHUD;
    [SerializeField] private EnemyHUD _enemyHUD;

    private ScriptablePlayer _playableCharacterScriptable;
    public ScriptablePlayer PlayableCharacterScriptable => _playableCharacterScriptable;
    private ScriptableEnemy _enemyScriptable;
    public ScriptableEnemy EnemyScriptable => _enemyScriptable;

    public void SpawnCharacters() {
        SpawnPlayableCharacter(PlayableCharacter.Knight, _playerSpawnPosition);
        SpawnEnemy(Enemies.Goblin, _enemySpawnPosition);
    }

    public void SpawnPlayableCharacter(PlayableCharacter playableCharacter, Transform transform) {
        // add index of character selection

        // using var instead of field
        // var playableCharacterScriptable = ResourceSystem.Instance.GetPlayableCharacter(playableCharacter);

        _playableCharacterScriptable = ResourceSystem.Instance.GetPlayableCharacter(playableCharacter);
        var playerSpawn = Instantiate(_playableCharacterScriptable.Prefab, transform);
        var stats = _playableCharacterScriptable.BaseStats;


        // stat change example
        // stats.CurrentHealth += 20;

        playerSpawn.SetStats(stats);
        
        _playerHUD.Initalise(_playableCharacterScriptable.Prefab);
        _playerHUD.InitalisePlayer(_playableCharacterScriptable.Prefab, _playableCharacterScriptable);
    }

    public void SpawnEnemy(Enemies enemy, Transform transform) {

        // using var instead of field
        // var enemyScriptable = ResourceSystem.Instance.GetEnemy(enemy);

        _enemyScriptable = ResourceSystem.Instance.GetEnemy(enemy);
        var enemySpawn = Instantiate(_enemyScriptable.Prefab, transform);
        var stats = _enemyScriptable.BaseStats;

        _enemyHUD.Initalise(_enemyScriptable.Prefab);
        _enemyHUD.InitialiseEnemy(_enemyScriptable.Prefab, _enemyScriptable);

        // apply buffs or whatever

        enemySpawn.SetStats(stats);
    }
}
