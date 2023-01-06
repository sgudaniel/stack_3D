using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolver : MonoBehaviour
{
    [SerializeField]
    private GameObject _stackPrefab;
    [SerializeField]
    private GameObject _scoreCounterPrefab;
    
    

    [SerializeField]
    private  GameObject _BGM;

    [SerializeField]
    private  GameObject _stackSoundEffect;
    [SerializeField]
    private  GameObject _gameoverSoundEffect;

    private static GameObject stackPrefabStatic;
    private static GameObject scoreCounterPrefabStatic;
    private static GameObject BGMStatic;
    private static GameObject stackSoundEffectStatic;
    private static GameObject gameOverSoundEffectStatic;
    

    void Awake() 
    {
        PrefabResolver.stackPrefabStatic = _stackPrefab;        
        PrefabResolver.scoreCounterPrefabStatic = _scoreCounterPrefab;
        PrefabResolver.BGMStatic = _BGM;
        PrefabResolver.stackSoundEffectStatic = _stackSoundEffect;
        PrefabResolver.gameOverSoundEffectStatic  = _gameoverSoundEffect;
    }


    public static GameObject StackPrefab
    {
        
            get
            {
                return PrefabResolver.stackPrefabStatic;
            }
        
    
    }
    

    public static GameObject ScoreCounterPrefab
    {
        
            get
            {
                return PrefabResolver.scoreCounterPrefabStatic;
            }
        
    }

    public static GameObject BGMPrefab
    {
        
            get
            {
                return PrefabResolver.BGMStatic;
            }
        
    }
    public static GameObject stackSoundEffectPrefab
    {
        
            get
            {
                return PrefabResolver.stackSoundEffectStatic;
            }
        
    }
    public static GameObject gameOverSoundEffectPrefab
    {
        
            get
            {
                return PrefabResolver.gameOverSoundEffectStatic;
            }
        
    }
}
