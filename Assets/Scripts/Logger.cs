using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Logger : MonoBehaviour
{


        void Awake()
        {            
            EventPublisher.Event.Subscribe(x=> Debug.Log(x));
        }

    }
