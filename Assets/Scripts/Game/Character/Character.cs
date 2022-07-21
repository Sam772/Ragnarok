using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Character : MonoBehaviour {
    // This scripts represents the base character class used for both players and enemies

    // Attributes of a character
    public string characterName;
    public int maxHealth;
    public int currentHealth;
    public int strength;
    public int defence;

    public void DealDamage(int playerStrength, int enemyDefence) {
        int damage = playerStrength - enemyDefence;
        if (damage < 0) damage = 1;
        currentHealth -= damage;
    }

    public bool CheckIfDead(GameObject character) {
        if (currentHealth <= 0)
            return true;    
        else
            return false;
    }
}
