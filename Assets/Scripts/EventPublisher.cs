using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class EventPublisher : MonoBehaviour
{

    private static EventPublisher instance = null; 
    static Subject<string> EventMsg = new Subject<string>();
    
    public static IObservable<string> Event { get { return EventMsg; } }

    private EventPublisher(){
        
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).
        Subscribe(x => EventMsg.OnNext("double_click"));

    }

    public static EventPublisher Instance{
        get{
            if(instance == null) instance = new EventPublisher();
            return instance;
        }
    }

}
