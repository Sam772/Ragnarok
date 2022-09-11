using UnityEngine;

public class GameManager : StaticInstanceGameManager<GameManager> {
    [SerializeField] private Player _player;
    public Player Player => _player;
    [SerializeField] private Enemy _enemy;
    public Enemy Enemy => _enemy;
    [SerializeField] private GameHUD _gameHUD;
    public GameHUD GameHUD => _gameHUD;

    void Start() => SetState(new Setup(this));

    public void OnAttack() => StartCoroutine(State.Attack());

    public void OnSkillSubMenu() => StartCoroutine(State.SkillSubMenu());

    public void OnSkill() => StartCoroutine(State.Skill());

    public void OnDefend() => StartCoroutine(State.Defend());
}