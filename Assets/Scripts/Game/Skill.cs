using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    // This script is temporarily used for skills on playable characters
    public string SkillName;
    public string SkillDescription;
    public int SkillCost;
    [SerializeField] private GameHUD _gameHUD;

    // Temporarily keeping skills here
    public void BolsterDefence(Player knight, PlayerHUD hud) {
        // if (knight.CurrentSkillPoints < 3) {
        //     _gameHUD.SetGameStatusText("You do not have enough SP to use this skill!");
        // } else {
        //     var stats = knight.Stats;
        //     stats.Defence += 2;
        //     knight.SetStats(stats);

        //     knight.CurrentSkillPoints -= 3;
        //     //hud.CharacterSkillPoints.text = "SP: " + knight.CurrentSkillPoints.ToString();
        // }
    }

    public void Berserk(Player berserker, PlayerHUD hud) {
        // if (berserker.CurrentSkillPoints < 2) {
        //     _gameHUD.SetGameStatusText("You do not have enough SP to use this skill!");
        // } else {
        //     var stats = berserker.Stats;
        //     stats.Strength += 2;
        //     berserker.SetStats(stats);

        //     berserker.CurrentSkillPoints -= 2;
        //     //hud.CharacterSkillPoints.text = "SP: " + berserker.CurrentSkillPoints.ToString();
        // }
    }
}
