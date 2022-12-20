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
        
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Subscribe(x => ClickEvent());

    }

    private void ClickEvent()
    {
        
        this._eventModel.msg = EventListener_.ClickEventMsg;
        EventMsg.OnNext(this._eventModel);
    }

    public static EventPublisher GetInstance(){
        
            if(_instance == null) _instance = new EventPublisher();
            return _instance;
        
    }

    public void Publish(EventModel ev)
    {
        EventMsg.OnNext(ev);
    }

}
