using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class EventPublisher
{

    private static EventPublisher instance = null; 
    static Subject<string> EventMsg = new Subject<string>();
    
    public IObservable<string> Event { get { return EventMsg; } }

    private EventPublisher(){
        
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).
        Subscribe(x => EventMsg.OnNext("click"));

    }

    public static EventPublisher getInstance(){
        
            if(instance == null) instance = new EventPublisher();
            return instance;
        
    }

}
