using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Character : MonoBehaviour {
    public string characterName;
    public int maxHealth;
    public int currentHealth;
    public int strength;
    public int defence;

    public void Awake() {
        currentHealth = maxHealth;
    }

    public void DealDamage() {
        
    }
}
