using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class MenuComponent : MonoBehaviour
{
    private Subject<Unit> theSubject;
    
    public IObservable<Unit> GetObservable
    {
        get
        {
            return this.theSubject.AsObservable();
        }
    }

    MenuComponent()
    {
        this.theSubject = new Subject<Unit>();
    }
}
