using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    // This scripts is temporarily used for skills on playable characters

    public string skillName;
    public string skillDescription;
    public int skillCost;
    [SerializeField] private GameHUD gameHUD;

    // Temporarily keeping skills here
    public void BolsterDefence(Player knight, PlayerHUD hud) {
        if (knight.currentSkillPoints < 3) {
            gameHUD.gamestatus.text = "You do not have enough SP to use this skill!";
        } else {
            knight.defence += 2;
            knight.currentSkillPoints -= 3;
            hud.characterSkillPoints.text = "SP: " + knight.currentSkillPoints.ToString();
        }
    }

    public void Berserk(Player berserker, PlayerHUD hud) {
        if (berserker.currentSkillPoints < 2) {
            gameHUD.gamestatus.text = "You do not have enough SP to use this skill!";
        } else {
            berserker.strength += 2;
            berserker.currentSkillPoints -= 2;
            hud.characterSkillPoints.text = "SP: " + berserker.currentSkillPoints.ToString();
        }
    }
}
