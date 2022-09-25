using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy {
    [SerializeField] private GoblinPunchSkill _goblinPunchSkill;
    public GoblinPunchSkill GoblinPunchSkill => _goblinPunchSkill;

    public override void ActivateSkill(ScriptableCharacter enemy) {
        CharacterAction = CharacterAction.ActivatingSkill;

        //Skills[0].Activate(player);
        GoblinPunchSkill.Activate(enemy);
    }
}