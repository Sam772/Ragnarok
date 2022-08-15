using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    // This script is temporarily used for skills on playable characters

    public string skillName;
    public string skillDescription;
    public int skillCost;
    [SerializeField] private GameHUD gameHUD;

    // Temporarily keeping skills here
    public void BolsterDefence(Player knight, PlayerHUD hud) {
        if (knight.currentSkillPoints < 3) {
            gameHUD.gamestatus.text = "You do not have enough SP to use this skill!";
        } else {
            var stats = knight.Stats;
            stats.Defence += 2;
            knight.SetStats(stats);

            knight.currentSkillPoints -= 3;
            hud.characterSkillPoints.text = "SP: " + knight.currentSkillPoints.ToString();
        }
    }

    public void Berserk(Player berserker, PlayerHUD hud) {
        if (berserker.currentSkillPoints < 2) {
            gameHUD.gamestatus.text = "You do not have enough SP to use this skill!";
        } else {
            var stats = berserker.Stats;
            stats.Strength += 2;
            berserker.SetStats(stats);

            berserker.currentSkillPoints -= 2;
            hud.characterSkillPoints.text = "SP: " + berserker.currentSkillPoints.ToString();
        }
    }
}
