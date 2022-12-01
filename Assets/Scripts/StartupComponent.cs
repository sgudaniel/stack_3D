using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class StartupComponent : MonoBehaviour
{
    
    private ScoreCounterComponent scoreCounterComponent;
    private List<StackComponent> stackComponent = new List<StackComponent>();
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
           
        this.stackComponent.Add(stackFactory.Create(new Vector3(0,1,0), false));
        //this.stackComponent.Add(stackFactory.Create(new Vector3(0,1.2f,0), false));

        this.RegisterEvents();
        
    }

    
    void Update()
    {
        
    }

    private void RegisterEvents()
    {
        evPublisher.Event.Where(x=> x.msg == "click").Subscribe(_=>{
            this.stackComponent.Add(stackFactory.Create(new Vector3(0,1,0), false));
        });
        
        
    }
}