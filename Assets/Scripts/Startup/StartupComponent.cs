using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class StartupComponent : MonoBehaviour
{
    
    private ScoreCounterComponent scoreCounterComponent;
    private List<StackComponent> stackComponents = new List<StackComponent>();
    private EventPublisher evPublisher = EventPublisher.getInstance();
    private Logger logger = Logger.getInstance();
    private StackFactory stackFactory = new StackFactory();
    
    private Subject<Unit> theSubject = new Subject<Unit>();


    StartupComponent()
    {
        
        
    }
    
    void Start()
    {
        var scoreCounterFactory = new ScoreCounterFactory();

        var inFrontOfCamera =  CameraUtil.inFront(Camera.main);
        var cameraRotation = CameraUtil.inFrontRotation(Camera.main);        

        this.scoreCounterComponent = scoreCounterFactory.Create(inFrontOfCamera, cameraRotation);
           
        this.stackComponents.Add(stackFactory.Create(new Vector3(0,GameState.CurrentCubeHeight,0), false));
        this.stackComponents[GameState.CubeIndex].stop();
        GameState.increaseState();
        this.stackComponents.Add(stackFactory.Create(new Vector3(0,GameState.CurrentCubeHeight,0), false));
        //this.stackComponent.Add(stackFactory.Create(new Vector3(0,1.2f,0), false));

        this.RegisterEvents();
        
    }

    
    void Update()
    {
        
    }

    private void RegisterEvents()
    {
        evPublisher.Event.Where(x=> x.msg == "click").Subscribe(_=>{
            StackComponent x = this.stackComponents[GameState.CubeIndex];
            StackComponent prev = this.stackComponents[GameState.CubeIndex - 1];
            x.stop();
            var t = x.transform;
            var prevT = prev.transform;

            var deltaX = Mathf.Abs(prevT.position.x - t.position.x);
            var middle = prevT.position.x + t.position.x /2;
            var xpos = middle - (prevT.position.x / 2);
            
            GameState.changeStackBounds(new Vector2(GameState.stackBounds.x-  deltaX ,GameState.stackBounds.y));

            if(GameState.stackBounds.x <= 0){
                return;
            }

            x.resize(new Vector3(xpos, t.position.y, t.position.z), new Vector3(GameState.stackBounds.x, t.localScale.y, t.localScale.z));

            x.CreateRubble(new Vector3( (t.position.x > 0)? t.position.x + (t.localScale.x / 2): t.position.x - (t.localScale.x / 2),t.localScale.y, t.localScale.z), new Vector3(deltaX,1,t.localScale.z));
            GameState.increaseState();
            this.stackComponents.Add(stackFactory.Create(new Vector3(0,GameState.CurrentCubeHeight,0), false));
            //this.scoreCounterComponent.Increase();
        });
        
        
    }
}