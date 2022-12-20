using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Logger
{
        private static Logger instance = null;
        private EventListener_ _evListener = EventListener_.getInstance();

        private Logger()
        {
            _evListener.AllEvent.Subscribe(x=> Debug.Log(x.msg));
        }

        public static Logger getInstance()
        {
        
            if(instance == null) instance = new Logger();
            return instance;
        
        }

    }
