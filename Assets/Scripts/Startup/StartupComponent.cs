using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class StartupComponent : MonoBehaviour
{

    private static EventPublisher _eventPublisher = EventPublisher.getInstance();
    private EventListener_ _evListener = EventListener_.getInstance();
    private ScoreCounterComponent _scoreCounterComponent;
    private List<StackComponent> _stackComponents = new List<StackComponent>();
    
    private Logger _logger = Logger.getInstance();
    private StackFactory _stackFactory = new StackFactory();


    StartupComponent()
    {


    }

    void Start()
    {
        var scoreCounterFactory = new ScoreCounterFactory();

        var inFrontOfCamera = CameraUtil.inFront(Camera.main);
        var cameraRotation = CameraUtil.inFrontRotation(Camera.main);

        this._scoreCounterComponent = scoreCounterFactory.Create(inFrontOfCamera, cameraRotation);

        StackComponent firstStack = _stackFactory.CreateFirstStack(new Vector3(0, GameState.CurrentCubeHeight, 0), false);
        this._stackComponents.Add(firstStack);

        GameState.increaseState(firstStack);

        this._stackComponents.Add(_stackFactory.Create(new Vector3(GameState.BOUNDARY, GameState.CurrentCubeHeight, 0), false, GameState.getPrevStackLocalScale()));
        //this.stackComponent.Add(stackFactory.Create(new Vector3(0,1.2f,0), false));

        this.RegisterEvents();

    }


    void Update()
    {

    }

    private void RegisterEvents()
    {
        _evListener.ClickEvent.Where(x => !GameState.GameOver).Subscribe(_ =>
        {
            
            StackComponent curStack = this._stackComponents[GameState.CubeIndex];
            StackComponent prevStack = this._stackComponents[GameState.CubeIndex - 1];
            

            var curStackTransform = curStack.transform;
            var prevStackTransform = prevStack.transform;

            var deltaX = Mathf.Abs(prevStackTransform.position.x - curStackTransform.position.x);
            var middle = prevStackTransform.position.x + curStackTransform.position.x / 2;
            var xpos = middle - (prevStackTransform.position.x / 2);

            GameState.changeStackBounds(new Vector2(GameState.StackBounds.x - deltaX, GameState.StackBounds.y));

            GameState.increaseState(curStack);
            this._scoreCounterComponent.Increase();

            if (GameState.StackBounds.x <= 0)
            {
                curStack.drop();
                GameState.GameisOver();
            }
            else
            {
                curStack.stop();
                curStack.CreateRubble(curStackTransform, deltaX);
                curStack.resize(new Vector3(xpos, curStackTransform.position.y, curStackTransform.position.z), new Vector3(GameState.StackBounds.x, curStackTransform.localScale.y, curStackTransform.localScale.z));

                
                GameState.ReverseStackMove();
                this._stackComponents.Add(_stackFactory.Create(new Vector3(GameState.BOUNDARY, GameState.CurrentCubeHeight, 0), false, GameState.getPrevStackLocalScale()));
                
            }


        });


    }
}