using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class EventListener_ : EventPublisher
{

    private static EventListener_ _instance = null;
    private static EventPublisher _eventPublisher = EventPublisher.GetInstance();

    private Subject<EventModel> _clickEvent = new Subject<EventModel>();
    public IObservable<EventModel> ClickEvent { get { return _clickEvent; } }
    public static String ClickEventMsg = "click";

    private Subject<EventModel> _gameoverEvent = new Subject<EventModel>();
    public IObservable<EventModel> GameOverEvent { get { return _gameoverEvent; } }
    public static String GameOverEventMsg = "GAME_OVER";

    private Subject<EventModel> _allEvent = new Subject<EventModel>();
    public IObservable<EventModel> AllEvent { get { return _allEvent; } }

    private EventListener_()
    {
        this.Event.Subscribe(x =>
        {

            if (x.msg == ClickEventMsg) _clickEvent.OnNext(x);
            if (x.msg == GameOverEventMsg) _clickEvent.OnNext(x);

            _allEvent.OnNext(x);

            
        }



        );

    }

    public static EventListener_ GetInstance()
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
