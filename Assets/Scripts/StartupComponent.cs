using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class StartupComponent : MonoBehaviour
{
    
    private CubeComponent cubeComponent;
    private ScoreCounterComponent scoreCounterComponent;

    StartupComponent(){
        
    }
    
    void Start()
    {
        
        var inFrontOfCamera=  Camera.main.transform.TransformPoint(Vector3.forward * 10);
        var cameraRotation = Camera.main.transform.rotation;
        var cameraRotationEuler = Quaternion.Euler(cameraRotation.x,cameraRotation.y,cameraRotation.z);
        var cubeFactory = new CubeFactory();
        var scoreCounterFactory = new ScoreCounterFactory();

        // this.sphereComponent =  sphereFactory.CreateSphere(new Vector3(0,6,0), false);
        
        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0,0,0)));
        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0,2,0)));
        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0,4,0)));


        this.scoreCounterComponent = scoreCounterFactory.Create(inFrontOfCamera, cameraRotationEuler);
        this.cubeComponent = cubeFactory.Create(new Vector3(0,1,0), false);

        //this.RegisterEvents();

        
    }

    
    void Update()
    {
        
    }

    private void RegisterEvents(){
        
        
        
    }
}