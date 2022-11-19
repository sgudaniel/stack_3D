using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolver : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private GameObject scoreCounterPrefab;
    
    private static GameObject cubePrefabStatic;
    private static GameObject scoreCounterPrefabStatic;
    

    void Awake() 
    {
        PrefabResolver.cubePrefabStatic = cubePrefab;        
        PrefabResolver.scoreCounterPrefabStatic = scoreCounterPrefab;
    }


    public static GameObject CubePrefab
    {
        
            get
            {
                return PrefabResolver.cubePrefabStatic;
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
