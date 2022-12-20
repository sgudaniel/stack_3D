using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class EventPublisher
{

    protected static EventPublisher _instance = null; 
    private EventModel _eventModel = EventModel.getDefaultInstance();
    protected static Subject<EventModel> EventMsg = new Subject<EventModel>(); 
    protected IObservable<EventModel> Event { get { return EventMsg; } }

    protected EventPublisher(){

        if(_instance != null) return;
        
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Subscribe(x => clickEvent());

    }

    private void clickEvent()
    {
        
        this._eventModel.msg = "click";
        EventMsg.OnNext(this._eventModel);
    }

    public static EventPublisher getInstance(){
        
            if(_instance == null) _instance = new EventPublisher();
            return _instance;
        
    }

    public static void publish(EventModel ev)
    {
        EventMsg.OnNext(ev);
    }

}
