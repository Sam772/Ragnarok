using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : State {

    public Setup(GameManager gameManager) : base(gameManager) {

    }

    public override IEnumerator Start() {
        GameManager.GameHUD.SetGameStatusText("Setting up battle!");

        CharacterManager.Instance.SpawnCharacters();

        GameManager.GameHUD.Initalise(GameManager.Player, GameManager.Enemy);

        yield return new WaitForSeconds(1.5f);

        GameManager.SetState(new PlayerTurn(GameManager));
    }

    #region old code
    
    // int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
    // _player = _playableCharacters[selectedCharacter];

    // _gameHUD.SkillName.text = _player.SkillOne.SkillName.ToString();
    // _gameHUD.SkillCost.text = _player.SkillOne.SkillCost.ToString();

    // _playerHUD = _spawnedPlayer.PlayerHUD;
    // _enemyHUD = _spawnedEnemy.EnemyHUD;

    // _player.CurrentSkillPoints = _player.MaxSkillPoints;
    //_playerHUD.CharacterSkillPoints.text = "SP: " + _player.MaxSkillPoints.ToString();

    // if (_player.CharacterName == "Knight") {
    //  var knightStats = _player.Stats;
    //  knightStats.Defence = 3;
    //  _player.SetStats(knightStats);

    // if (_player.CharacterName == "Berserker") {
    //  var berserkStats = _player.Stats;
    //  berserkStats.Strength = 7;
    //  _player.SetStats(berserkStats);

    #endregion
}
