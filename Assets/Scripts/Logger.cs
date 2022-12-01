using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Logger
{
        private static Logger instance = null;
        private EventPublisher evPublisher = EventPublisher.getInstance();

        private Logger()
        {
            evPublisher.Event.Subscribe(x=> Debug.Log(x));
        }

        public static Logger getInstance()
        {
        
            if(instance == null) instance = new Logger();
            return instance;
        
        }

    }
