using System.Collections;
using System.Collections.Generic;


public static class GameState
{
    public static int CubeIndex = 0;
    
    public static float  CurrentCubeHeight = 0.58f;
    public static float LastCubeHeight = 0;
    public static int Score  = 0;

    public static void increaseState(){
        CubeIndex += 1;
        Score += 1;
        LastCubeHeight = CurrentCubeHeight;
        CurrentCubeHeight += 0.12f;
    }

}
