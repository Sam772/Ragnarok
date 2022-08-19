using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Character : MonoBehaviour {
    // This scripts represents the base character class used for both players and enemies

    // Attributes of a character
    public string CharacterName;
    // public int maxHealth;
    // public int currentHealth;
    // public int strength;
    // public int defence;

    public Stats Stats { get; private set; }

    public virtual void SetStats(Stats stats) {
        Stats = stats;
    }

    public virtual void TakeDamage(int targetStrength, int myDefence) {
        int damage = targetStrength - myDefence;
        if (damage <= 0) damage = 1;
        //currentHealth -= damage;

        var stats = Stats;
        stats.CurrentHealth -= damage;

        SetStats(stats);
    }

    public void Defend() {
        //defence *= 2;

        var stats = Stats;
        stats.Defence *= 2;
        
        SetStats(stats);
    }

    public IEnumerator ReturnToOriginalDefence() {
        yield return new WaitForSeconds(2f);

        // bug here if too fast
        
        //defence /= 2;

        var stats = Stats;
        stats.Defence /= 2;
        
        SetStats(stats);

        Debug.Log("Player DEF: " + stats.Defence);
    }

    public bool CheckIfDead(GameObject character) {
        if (Stats.CurrentHealth <= 0)
            return true;
        else
            return false;
    }
}
