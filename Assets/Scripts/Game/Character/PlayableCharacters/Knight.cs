using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player {
    [SerializeField] private BolsterDefenceSkill _bolsterDefenceSkill;
    public BolsterDefenceSkill BolsterDefenceSkill => _bolsterDefenceSkill;

    // get the array of skills from scriptableplayer instead

    public override void ActivateSkill(ScriptablePlayer player) {
        CharacterAction = CharacterAction.ActivatingSkill;

        BolsterDefenceSkill.Activate(player);
    }
}
