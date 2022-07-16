using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    private enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };
    private BattleState state;
    [SerializeField] private Player player;
    [SerializeField] private Transform playerStart;
    [SerializeField] private PlayerHUD playerHUD;
    [SerializeField] private Enemy enemy;
    [SerializeField] private CharacterHUD enemyHUD;
    [SerializeField] private Transform enemyStart;
    [SerializeField] private GameHUD gameHUD;
    [SerializeField] private GameObject attackButton;
    [SerializeField] private GameObject skillButton;
    [SerializeField] private GameObject skillBox;
    [SerializeField] private Player[] characters;

    private void Start() {
        gameHUD.gamestatus.text = "Setting up battle!";
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    private IEnumerator SetupBattle() {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        player = characters[selectedCharacter];
        gameHUD.skillName.text = player.skillOne.skillName.ToString();
        gameHUD.skillCost.text = player.skillOne.skillCost.ToString();
        Instantiate(player.gameObject, playerStart).GetComponent<Player>().gameObject.SetActive(true);
        Instantiate(enemy.gameObject, enemyStart).GetComponent<Enemy>();
        enemyHUD = FindObjectOfType<EnemyHUD>();
        playerHUD = FindObjectOfType<PlayerHUD>();
        player.currentHealth = player.maxHealth;
        enemy.currentHealth = enemy.maxHealth;
        player.currentSkillPoints = player.maxSkillPoints;
        playerHUD.characterSkillPoints.text = "SP: " + player.maxSkillPoints.ToString();
        //player.PlayerLevelSetup();

        // temporary solution
        if (player.characterName == "Knight") player.defence = 3;
        if (player.characterName == "Berserker") player.strength = 7;

        yield return new WaitForSeconds(1.5f);

        state = BattleState.PLAYERTURN;
        gameHUD.gamestatus.text = "Choose an action!";
    }

    public void PlayerTurn() {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());   
    }

    private IEnumerator PlayerAttack() {
        gameHUD.gamestatus.text = player.characterName + " is attacking!";
        enemy.DealDamage(player.strength, enemy.defence);
        enemyHUD.healthText.text = "HP: " + enemy.currentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        if (enemy.CheckIfDead(enemy.gameObject)) {
            state = BattleState.WON;
            EndBattle();
        } else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyAttack());
        }
    }

    public void PlayerSkill() {
        // show the skill box
        if (skillBox.activeSelf == false)  {
            skillBox.SetActive(true);
        } else {
            skillBox.SetActive(false);
        }
    }

    public void PlayerSkillTurn() {
        if (state != BattleState.PLAYERTURN) return;
        
        StartCoroutine(PlayerSkillOne());
    }

    public IEnumerator PlayerSkillOne() {
        gameHUD.gamestatus.text = player.characterName + " used " + player.skillOne.skillName + "!";

        // temporary solution
        switch(player.characterName) {
            case "Knight":
            player.skillOne.BolsterDefence(player, playerHUD);
            break;

            case "Berserker":
            player.skillOne.Berserk(player, playerHUD);
            break;
        }

        yield return new WaitForSeconds(1.5f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyAttack());
    }

    private IEnumerator EnemyAttack() {
        gameHUD.gamestatus.text = enemy.characterName + " is attacking!";
        player.DealDamage(enemy.strength, player.defence);
        playerHUD.healthText.text = "HP: " + player.currentHealth.ToString();

        yield return new WaitForSeconds(1.5f);

        if (player.CheckIfDead(player.gameObject)) {
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            gameHUD.gamestatus.text = "Choose an action!";
        }
    }

    private void EndBattle() {

        attackButton.SetActive(false);
        gameHUD.menuButton.SetActive(true);

        if (state == BattleState.WON) {
            gameHUD.gamestatus.text = "You have won!";
            // Note
            // Object reference exception
            player.levelSystem.AddExperience(100);
        } else
            gameHUD.gamestatus.text = "You have lost!";
    }
}
