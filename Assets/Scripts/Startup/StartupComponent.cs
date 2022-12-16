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

        var inFrontOfCamera = CameraUtil.inFront(Camera.main);
        var cameraRotation = CameraUtil.inFrontRotation(Camera.main);

        this.scoreCounterComponent = scoreCounterFactory.Create(inFrontOfCamera, cameraRotation);

        StackComponent firstStack = stackFactory.CreateFirstStack(new Vector3(0, GameState.CurrentCubeHeight, 0), false);
        this.stackComponents.Add(firstStack);

        GameState.increaseState(firstStack);

        this.stackComponents.Add(stackFactory.Create(new Vector3(GameState.BOUNDARY, GameState.CurrentCubeHeight, 0), false, GameState.getPrevStackLocalScale()));
        //this.stackComponent.Add(stackFactory.Create(new Vector3(0,1.2f,0), false));

        this.RegisterEvents();

    }


    void Update()
    {

    }

    private void RegisterEvents()
    {
        evPublisher.Event.Where(x => x.msg == "click" && !GameState.GameOver).Subscribe(_ =>
        {
            StackComponent curStack = this.stackComponents[GameState.CubeIndex];
            StackComponent prevStack = this.stackComponents[GameState.CubeIndex - 1];
            

            var curStackTransform = curStack.transform;
            var prevStackTransform = prevStack.transform;

            var deltaX = Mathf.Abs(prevStackTransform.position.x - curStackTransform.position.x);
            var middle = prevStackTransform.position.x + curStackTransform.position.x / 2;
            var xpos = middle - (prevStackTransform.position.x / 2);

            GameState.changeStackBounds(new Vector2(GameState.StackBounds.x - deltaX, GameState.StackBounds.y));

            GameState.increaseState(curStack);
            this.scoreCounterComponent.Increase();

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
                this.stackComponents.Add(stackFactory.Create(new Vector3(GameState.BOUNDARY, GameState.CurrentCubeHeight, 0), false, GameState.getPrevStackLocalScale()));

                Camera.main.transform.position = CameraUtil.increaseHeight(Camera.main);
                
            }


        });


    }
}