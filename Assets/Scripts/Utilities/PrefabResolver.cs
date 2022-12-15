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
    private static GameObject menuPrefabStatic;
    

    void Awake() 
    {
        PrefabResolver.stackPrefabStatic = stackPrefab;        
        PrefabResolver.scoreCounterPrefabStatic = scoreCounterPrefab;
        PrefabResolver.menuPrefabStatic = menuPrefabStatic;
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

    public static GameObject MenuPrefab
    {
        get
        {
            return PrefabResolver.menuPrefabStatic;
        }
    }
}
