using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class StartupComponent : MonoBehaviour
{
    
    private List<StackComponent> stackComponent = new List<StackComponent>();
    private ScoreCounterComponent scoreCounterComponent;
    private EventPublisher evPublisher = EventPublisher.getInstance();
    private Logger logger = Logger.getInstance();

    StartupComponent()
    {
        
        
    }
    
    void Start()
    {
        
        var stackFactory = new StackFactory();
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
        //evPublisher.Event.Where(x=> x == "click").Subscribe(_=> Debug.Log("hihih"));
        
        
    }
}