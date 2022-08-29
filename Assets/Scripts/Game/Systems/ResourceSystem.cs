using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceSystem : StaticInstance<ResourceSystem> {
    public List<ScriptableCharacter> CharacterList { get; private set; }
    public List<ScriptablePlayer> PlayableCharacterList { get; private set; }
    public List<ScriptableEnemy> EnemyList { get; private set; }
    private Dictionary<PlayableCharacter, ScriptablePlayer> _playableCharactersDictionary;
    private Dictionary<Enemies, ScriptableEnemy> _enemiesDictionary;

    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
        CharacterList = Resources.LoadAll<ScriptableCharacter>("Characters").ToList();
        PlayableCharacterList = Resources.LoadAll<ScriptablePlayer>("PlayableCharacters").ToList();
        EnemyList = Resources.LoadAll<ScriptableEnemy>("Enemies").ToList();

        _playableCharactersDictionary = PlayableCharacterList.ToDictionary(r => r.PlayableCharacter, r => r);
        _enemiesDictionary = EnemyList.ToDictionary(r => r.Enemies, r => r);

        //print("Keys: " + _playableCharactersDictionary.Keys);
        //print("Values: " + _playableCharactersDictionary.Values);
    }

    public ScriptablePlayer GetPlayableCharacter(PlayableCharacter playableCharacters) => _playableCharactersDictionary[playableCharacters];
    public ScriptableEnemy GetEnemy(Enemies enemies) => _enemiesDictionary[enemies];
    public ScriptablePlayer GetRandomPlayableCharacter() => PlayableCharacterList[Random.Range(0, PlayableCharacterList.Count)];
}
