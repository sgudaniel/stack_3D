using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class EventPublisher
{

    private static EventPublisher instance = null; 
    private EventModel eventModel = EventModel.getDefaultInstance();
    static Subject<EventModel> EventMsg = new Subject<EventModel>(); 

    public IObservable<EventModel> Event { get { return EventMsg; } }

    private EventPublisher(){
        
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).
        Subscribe(x => clickEvent());

    }

    private void clickEvent()
    {
        this.eventModel.msg = "click";
        EventMsg.OnNext(this.eventModel);
    }

    public static EventPublisher getInstance(){
        
            if(instance == null) instance = new EventPublisher();
            return instance;
        
    }

    public static void publish(EventModel ev)
    {
        EventMsg.OnNext(ev);
    }

}
