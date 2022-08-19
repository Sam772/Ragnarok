using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : StaticInstance<CharacterManager> {

    [Header("Spawn Positions")]
    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private Transform _enemySpawnPosition;

    public void SpawnCharacters() {
        SpawnPlayableCharacter(PlayableCharacter.Knight, _playerSpawnPosition);
        SpawnEnemy(Enemies.Goblin, _enemySpawnPosition);
    }

    public void SpawnPlayableCharacter(PlayableCharacter playableCharacter, Transform transform) {
        // add index of character selection

        var knightScriptable = ResourceSystem.Instance.GetPlayableCharacter(playableCharacter);

        var playerSpawn = Instantiate(knightScriptable.Prefab, transform);

        var stats = knightScriptable.BaseStats;

        //stats.CurrentHealth += 20;

        playerSpawn.SetStats(stats);
    }

    public void SpawnEnemy(Enemies enemy, Transform transform) {
        var goblinScriptable = ResourceSystem.Instance.GetEnemy(enemy);

        var enemySpawn = Instantiate(goblinScriptable.Prefab, transform);

        var stats = goblinScriptable.BaseStats;

        // apply buffs or whatever

        // enemySpawn.SetStats(stats);
    }
}
