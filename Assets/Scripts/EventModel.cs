using System.Collections;
using System.Collections.Generic;


public class EventModel
{
    public string msg;
    public int CubeIndex;
    public int LastCubeHeight;
    public int Score;

    public EventModel(string msg, int cubeindex, int lastcubeheight, int score){
        this.msg = msg;
        this.CubeIndex = cubeindex;
        this.LastCubeHeight = lastcubeheight;
        this.Score = score;
    }

    public static EventModel getDefaultInstance(){
        return new EventModel("default",0,0,0);
    }
}
