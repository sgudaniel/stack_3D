using System.Collections;
using System.Collections.Generic;


public class EventModel
{
    public string msg;

    public EventModel(string msg){
        this.msg = msg;
        
    }

    public static EventModel getDefaultInstance(){
        return new EventModel("default");
    }
}
