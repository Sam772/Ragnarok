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
                //ScriptableSkill.Activate(CharacterManager.Instance.PlayableCharacterScriptable);
                break;
            default:
                break;
        }
    }
}

public enum SkillState {
    NotActivating = 0,
    Activating = 1
}
