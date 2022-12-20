using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolver : MonoBehaviour
{
    [SerializeField]
    private GameObject _stackPrefab;
    [SerializeField]
    private GameObject _scoreCounterPrefab;
    
    private static GameObject stackPrefabStatic;
    private static GameObject scoreCounterPrefabStatic;
    

    void Awake() 
    {
        PrefabResolver.stackPrefabStatic = _stackPrefab;        
        PrefabResolver.scoreCounterPrefabStatic = _scoreCounterPrefab;
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
}
