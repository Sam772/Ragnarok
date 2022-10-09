using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy {

    public override void ActivateSkill(ScriptableCharacter enemy) {
        CharacterAction = CharacterAction.UsingSkill;

        Skills[0].Activate(enemy);
    }
}