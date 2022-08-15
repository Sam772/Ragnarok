using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : StaticInstance<CharacterManager> {

    public void SpawnCharacters() {
        SpawnCharacter(PlayableCharacter.Knight, new Vector3(1, 0, 0));
    }

    public void SpawnCharacter(PlayableCharacter playableCharacter, Vector3 position) {
        // add index of character selection

        var knightScriptable = ResourceSystem.Instance.GetPlayableCharacter(playableCharacter);

        var playerSpawn = Instantiate(knightScriptable.Prefab, position, Quaternion.identity, transform);

        var stats = knightScriptable.BaseStats;

        //stats.CurrentHealth += 20;

        playerSpawn.SetStats(stats);
    }
}
