using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CubeComponent : MonoBehaviour
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

    CubeComponent(){
        this.theSubject = new Subject<Unit>();
    }

    void Start()
    {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // private void OnMouseDown()
    // {
    //  this.theSubject.OnNext(Unit.Default);
    // }

}
