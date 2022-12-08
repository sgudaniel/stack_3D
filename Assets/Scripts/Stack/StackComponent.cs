using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class StackComponent : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Subject<Unit> theSubject;

    public IReactiveProperty<float> sizeX { get; private set; }
    public IReadOnlyReactiveProperty<bool> isEmpty { get; private set; }

    private float moveSpeed = 0.3f;
    private float boundary = 4f;
    private float transition = 0f;
    private bool mustStop = false;


    public IObservable<Unit> GetObservable
    {
        get
        {
            return this.theSubject.AsObservable();
        }
    }

    StackComponent()
    {
        this.theSubject = new Subject<Unit>();

        // sizeX = new ReactiveProperty<float>(this.transform.localScale.x);
        // isEmpty = sizeX.Select(x => x <= 0).ToReactiveProperty();
    }

    void Start()
    {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!mustStop)
        {
            transition += Time.deltaTime * moveSpeed;

            var x = Mathf.Sin(transition * boundary);
            var y = this.transform.localPosition.y;
            var z = this.transform.localPosition.z;

            move(x, y, z);
        }

    }

    void Slice(Vector3 sliced)
    {

        this.transform.localScale = new Vector3(this.transform.localScale.x - Mathf.Abs(sliced.x - this.transform.position.x),
                                                this.transform.localScale.y,
                                                this.transform.localScale.z - Mathf.Abs(sliced.z - this.transform.position.z));
    }

    public void resize(Vector3 pos, Vector3 scale)
    {
        this.transform.position = pos;
        this.transform.localScale = scale;
        
    }

    public void CreateRubble(Vector3 pos, Vector3 scale)
    {
        
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.localPosition = pos;
        //print(pos);
        go.transform.localScale = scale;
        go.AddComponent<Rigidbody>();    
    }

    void move(float x, float y, float z)
    {
        this.transform.localPosition = new Vector3(x, y, z);
    }

    void ChangeColor(Color color)
    {
        this.gameObject.GetComponent<Renderer>().material.color = color;
    }

    void increaseMoveSpeed(float ms)
    {
        this.moveSpeed = ms;
    }

    public void stop()
    {
        this.mustStop = true;
    }
    // private void OnMouseDown()
    // {
    //  this.theSubject.OnNext(Unit.Default);
    // }

}
