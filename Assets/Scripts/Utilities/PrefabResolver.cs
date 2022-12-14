using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolver : MonoBehaviour
{
    [SerializeField]
    private GameObject stackPrefab;
    [SerializeField]
    private GameObject scoreCounterPrefab;
    
    private static GameObject stackPrefabStatic;
    private static GameObject scoreCounterPrefabStatic;
    

    void Awake() 
    {
        PrefabResolver.stackPrefabStatic = stackPrefab;        
        PrefabResolver.scoreCounterPrefabStatic = scoreCounterPrefab;
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
