using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Bolster Defence Skill")]
public class BolsterDefenceSkill : ScriptableSkill {

    public override void Activate(ScriptableCharacter player) {
        player = CharacterManager.Instance.PlayableCharacterScriptable;

        var playerStats = player.Prefab.Stats;

        playerStats.Defence += 2;

        player.Prefab.SetStats(playerStats);

        GameManager.Instance.GameHUD.SetGameStatusText(player.ScriptableCharacterName + " used bolster defence!");
    }

}
