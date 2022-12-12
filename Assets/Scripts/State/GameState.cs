using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public const float BOUNDS_SIZE = 1f;
    public const int COMBO_GAIN = 5;

    public const float BOUNDARY = 3f;

    

    private static int _CubeIndex = 0;
    private static int _Score  = 0;
    private static int _Combo = 0;
    private static float _StackSpeed = 1f;
    private static float  _CurrentCubeHeight = 0.58f;
    private static bool _GameOver = false;

    private static StackComponent prevStack;

    private static Vector2 _StackBounds = new Vector2(BOUNDS_SIZE, BOUNDS_SIZE);

    

    public static int CubeIndex { get => _CubeIndex; set => _CubeIndex = value; }
    public static int Score { get => _Score; set => _Score = value; }
    public static int Combo { get => _Combo; set => _Combo = value; }
    public static float StackSpeed { get => _StackSpeed; set => _StackSpeed = value; }
    public static float CurrentCubeHeight { get => _CurrentCubeHeight; set => _CurrentCubeHeight = value; }
    public static bool GameOver { get => _GameOver;}
    public static StackComponent PrevStack { get => prevStack; set => prevStack = value; }
    public static Vector2 StackBounds { get => _StackBounds;}

    public static void increaseState(StackComponent sc){
        CubeIndex += 1;
        Score += 1;
        PrevStack = sc;
        CurrentCubeHeight += 0.12f;
    }

    public static Vector3 getPrevStackLocalScale(){
        return PrevStack.transform.localScale;
    }

    public static void changeStackBounds(Vector2 sb){
        _StackBounds = sb;
    }

    public static void GameisOver(){
        _GameOver = true;
    }

    

}
