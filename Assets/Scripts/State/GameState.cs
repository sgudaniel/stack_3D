using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    private const float BOUNDS_SIZE = 1f;
    private const int COMBO_GAIN = 5;

    public static int CubeIndex = 0;
    public static float  CurrentCubeHeight = 0.58f;
    public static float LastCubeHeight = 0;
    public static int Score  = 0;
    public static int Combo = 0;
    
    public static Vector2 stackBounds = new Vector2(BOUNDS_SIZE, BOUNDS_SIZE);

    public static void increaseState(){
        CubeIndex += 1;
        Score += 1;
        LastCubeHeight = CurrentCubeHeight;
        CurrentCubeHeight += 0.12f;
    }

    public static void changeStackBounds(Vector2 sb){
        stackBounds = sb;
    }

}
