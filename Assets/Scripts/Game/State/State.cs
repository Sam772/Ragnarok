using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
    // not really needed if we have singleton?
    protected GameManager GameManager;

    public State(GameManager gameManager) {
        GameManager = gameManager;
    }

    public virtual IEnumerator Start() {
        yield break;
    }

    public virtual IEnumerator Attack() {
        yield break;
    }

    public virtual IEnumerator Defend() {
        yield break;
    }

    public virtual IEnumerator Skill() {
        yield break;
    }
}
