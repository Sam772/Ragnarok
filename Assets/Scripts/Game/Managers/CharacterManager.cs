using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : StaticInstance<CharacterManager> {

    [Header("Spawn Positions")]
    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private Transform _enemySpawnPosition;
    [SerializeField] private PlayerHUD _playerHUD;
    [SerializeField] private EnemyHUD _enemyHUD;

    [Header("Player")]
    private Player _player;
    public Player Player => _player;
    private ScriptablePlayer _playableCharacterScriptable;
    public ScriptablePlayer PlayableCharacterScriptable => _playableCharacterScriptable;

    [Header("Enemy")]
    private ScriptableEnemy _enemyScriptable;
    public ScriptableEnemy EnemyScriptable => _enemyScriptable;

    // List of playable characters
    [SerializeField] private ScriptablePlayer[] _playableCharacters;

    public void SpawnCharacters() {
        SpawnPlayableCharacter(GetCharacterFromPrefs(), _playerSpawnPosition);
        SpawnEnemy(Enemies.Goblin, _enemySpawnPosition);
    }

    public void SpawnPlayableCharacter(PlayableCharacter playableCharacter, Transform transform) {
        // using var instead of field
        // var playableCharacterScriptable = ResourceSystem.Instance.GetPlayableCharacter(playableCharacter);

        _playableCharacterScriptable = ResourceSystem.Instance.GetPlayableCharacter(playableCharacter);
        var playerSpawn = Instantiate(_playableCharacterScriptable.Prefab, transform);
        
        // gets the original stats of the character
        var stats = _playableCharacterScriptable.BaseStats;

        var skills = _playableCharacterScriptable.Skills;

        // stat change example
        // stats.CurrentHealth += 20;

        // set the level here
        //stats.Level = PlayerPrefs.GetInt("level", stats.Level);
        
        // have a way to check which stats to use

        // playerSpawn.SetStats(stats);
        // playerSpawn.SetSkills(skills);
        
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

    // replace this function in the spawnplayablecharacter call
    public PlayableCharacter GetCharacterFromPrefs() {
        // add index of character selection
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        _player = (Player) _playableCharacters[selectedCharacter].Prefab;

        return ResourceSystem.Instance.GetPlayableCharacterType(_playableCharacters[selectedCharacter]);
    }
}
