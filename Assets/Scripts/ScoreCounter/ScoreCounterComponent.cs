using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class ScoreCounterComponent : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Subject<Unit> theSubject;

    public IObservable<Unit> GetObservable
    {
        get
        {
            return this.theSubject.AsObservable();
        }
    }

    ScoreCounterComponent(){
        this.theSubject = new Subject<Unit>();
    }

    void Start()
    {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }    

}
