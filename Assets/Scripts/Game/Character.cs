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
    public TMP_Text healthText;

    public void Awake() {
        currentHealth = maxHealth;
        healthText.text = maxHealth.ToString();
    }
}
