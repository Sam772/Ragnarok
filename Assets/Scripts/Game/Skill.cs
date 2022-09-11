using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    // This script is as a skill holder for playable characters
    public ScriptableSkill ScriptableSkill;
    public SkillState SkillState = SkillState.NotActivating;

    private void Update() {
        ChangeSkillState();

        // need a way to tell if playerskillbutton is pressed
    }

    private void ChangeSkillState() {
        switch(SkillState) {
            case SkillState.NotActivating:
                break;
            case SkillState.Activating:
                GameManager.Instance.GameHUD.PlayerSkillButton.SetActive(false);
                ScriptableSkill.Activate(CharacterManager.Instance.PlayableCharacterScriptable);
                break;
            default:
                break;
        }
    }

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

public enum SkillState {
    NotActivating = 0,
    Activating = 1
}
