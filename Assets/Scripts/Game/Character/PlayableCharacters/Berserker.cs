using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Player {
    [SerializeField] private VigorUpSkill _vigorUpSkill;
    public VigorUpSkill VigorUpSkill => _vigorUpSkill;

    public override void ActivateSkill(ScriptablePlayer player) {
        CharacterAction = CharacterAction.ActivatingSkill;
        
        VigorUpSkill.Activate(player);
    }
}
