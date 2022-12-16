using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public const float BOUNDS_SIZE = 1f;
    public const int COMBO_GAIN = 5;

    public const float BOUNDARY = 2f;

    

    private static int _cubeIndex = 0;
    private static int _score  = 0;
    private static int _combo = 0;
    private static float _stackSpeed = 1f;
    private static float  _currentCubeHeight = 0.58f;
    
    private static bool _stackReverseMove = false;
    private static bool _gameOver = false;

    private static StackComponent _prevStack;

    private static Vector2 _stackBounds = new Vector2(BOUNDS_SIZE, BOUNDS_SIZE);

    

    public static int CubeIndex { get => _cubeIndex; set => _cubeIndex = value; }
    public static int Score { get => _score; set => _score = value; }
    public static int Combo { get => _combo; set => _combo = value; }
    public static float StackSpeed { get => _stackSpeed; set => _stackSpeed = value; }
    public static float CurrentCubeHeight { get => _currentCubeHeight; set => _currentCubeHeight = value; }
    public static bool GameOver { get => _gameOver;}
    public static StackComponent PrevStack { get => _prevStack; set => _prevStack = value; }
    public static Vector2 StackBounds { get => _stackBounds;}

    public static bool StackReverseMove { get => _stackReverseMove;}

    public static void increaseState(StackComponent sc){
        CubeIndex += 1;
        Score += 1;
        PrevStack = sc;
        CurrentCubeHeight += 0.11f;
    }

    public static Vector3 getPrevStackLocalScale(){
        return PrevStack.transform.localScale;
    }

    public static void changeStackBounds(Vector2 sb){
        _stackBounds = sb;
    }

    public static void GameisOver(){
        _gameOver = true;
    }

    public static void ReverseStackMove(){
        _stackReverseMove = !_stackReverseMove;
    }

    

}
