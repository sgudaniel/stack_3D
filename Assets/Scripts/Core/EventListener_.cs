using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class EventListener_ : EventPublisher
{

    private static EventListener_ _instance = null;
    private static EventPublisher _eventPublisher = EventPublisher.getInstance();

    private Subject<EventModel> _clickEvent = new Subject<EventModel>();
    public IObservable<EventModel> ClickEvent { get { return _clickEvent; } }

    private Subject<EventModel> _allEvent = new Subject<EventModel>();
    public IObservable<EventModel> AllEvent { get { return _allEvent; } }

    private EventListener_()
    {
        this.Event.Subscribe(x =>
        {

            if (x.msg == "click") _clickEvent.OnNext(x);

            _allEvent.OnNext(x);

            
        }



        );

    }

    public static EventListener_ getInstance()
    {

        if (_instance == null) EventListener_._instance = new EventListener_();
        return _instance;

    }

    // private void clickEvent()
    // {
    //     this.eventModel.msg = "click";
    //     EventMsg.OnNext(this.eventModel);
    // }



}
