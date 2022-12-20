using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class StackComponent : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Subject<Unit> theSubject;

    private float _moveSpeed = GameState.StackSpeed;
    private float _boundary = GameState.BOUNDARY;
    private float _transition = 0f;
    private bool _mustStop = false;


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
        if (!_mustStop)
        {
            _transition += Time.deltaTime;

            
            var x = this.transform.localPosition.x;
            var y = this.transform.localPosition.y;
            var z = this.transform.localPosition.z;

            x = Mathf.PingPong(_transition * _moveSpeed, _boundary*2) - _boundary;
            
            if(GameState.StackReverseMove) x *= -1;

            Move(x, y, z);
        }

    }

    void Slice(Vector3 sliced)
    {

        this.transform.localScale = new Vector3(this.transform.localScale.x - Mathf.Abs(sliced.x - this.transform.position.x),
                                                this.transform.localScale.y,
                                                this.transform.localScale.z - Mathf.Abs(sliced.z - this.transform.position.z));
    }

    public void Resize(Vector3 pos, Vector3 scale)
    {
        this.transform.position = pos;
        this.transform.localScale = scale;
        
    }

    public void CreateRubble(Transform sc, float deltaX)
    {

        var posX = (sc.position.x > 0)? sc.position.x + (sc.localScale.x / 2): sc.position.x - (sc.localScale.x / 2);

        var pos = new Vector3( posX ,sc.position.y, sc.position.z);
        var scale  = new Vector3(deltaX,sc.localScale.y,sc.localScale.z);
        

        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.localPosition = pos;
        go.transform.localScale = scale;
        go.AddComponent<Rigidbody>();   
        //go.GetComponent<Renderer>().material.color =  new Color(0, 204, 102);
    }

    void Move(float x, float y, float z)
    {
        this.transform.localPosition = new Vector3(x, y, z);
    }

    void ChangeColor(Color color)
    {
        this.gameObject.GetComponent<Renderer>().material.color = color;
    }

    void Increase_MoveSpeed(float ms)
    {
        this._moveSpeed = ms;
    }

    public void Stop()
    {
        this._mustStop = true;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Drop()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
    }
    // private void OnMouseDown()
    // {
    //  this.theSubject.OnNext(Unit.Default);
    // }

}
