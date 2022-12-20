using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Logger
{
        private static Logger _instance = null;
        private EventListener_ _evListener = EventListener_.GetInstance();

        private Logger()
        {
            _evListener.AllEvent.Subscribe(x=> Debug.Log(x.msg));
        }

        public static Logger GetInstance()
        {
        
            if(_instance == null) _instance = new Logger();
            return _instance;
        
        }

    }
