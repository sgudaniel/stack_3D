using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class StartupComponent : MonoBehaviour
{

    private static EventPublisher _eventPublisher = EventPublisher.GetInstance();
    private EventListener_ _evListener = EventListener_.GetInstance();
    private ScoreCounterComponent _scoreCounterComponent;
    private List<StackComponent> _stackComponents = new List<StackComponent>();
    
    private Logger _logger = Logger.GetInstance();
    private StackFactory _stackFactory = new StackFactory();

    private AudioFactory _audioFactory = new AudioFactory();


    StartupComponent()
    {


    }

    void Start()
    {
        var scoreCounterFactory = new ScoreCounterFactory();

        var inFrontOfCamera = CameraUtil.InFront(Camera.main);
        var cameraRotation = CameraUtil.InFrontRotation(Camera.main);

        this._scoreCounterComponent = scoreCounterFactory.Create(inFrontOfCamera, cameraRotation);

        StackComponent firstStack = _stackFactory.CreateIMmoveableStack(new Vector3(0, GameState.CurrentCubeHeight, 0), false);
        this._stackComponents.Add(firstStack);

        GameState.increaseState(firstStack);

        this._stackComponents.Add(_stackFactory.CreateMoveableStack(new Vector3(GameState.BOUNDARY, GameState.CurrentCubeHeight, 0), false, GameState.getPrevStackLocalScale()));
        //this.stackComponent.Add(stackFactory.Create(new Vector3(0,1.2f,0), false));

        var audio = _audioFactory.Create(PrefabResolver.BGMPrefab);
        audio.Play();


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
            var deltaZ = Mathf.Abs(prevStackTransform.position.z - curStackTransform.position.z);

            var middleX = (prevStackTransform.position.x + curStackTransform.position.x) / 2;
            var middleZ = (prevStackTransform.position.z + curStackTransform.position.z) / 2;

            var xpos = middleX - (prevStackTransform.position.x / 2);
            var zpos = middleZ - (prevStackTransform.position.z / 2);

            GameState.changeStackBounds(new Vector2(GameState.StackBounds.x - deltaX, GameState.StackBounds.y - deltaZ));

            GameState.increaseState(curStack);
            this._scoreCounterComponent.Increase();

            var audio = _audioFactory.Create(PrefabResolver.stackSoundEffectPrefab);
            audio.Play();

            if (GameState.StackBounds.x <= 0 || GameState.StackBounds.y <= 0)
            {
                curStack.Drop();
                GameState.GameisOver();

                var audiox = _audioFactory.Create(PrefabResolver.gameOverSoundEffectPrefab);
            audiox.Play();
            }
            else
            {
                curStack.Stop();
                
                if(GameState.ZStackMove) curStack.CreateRubbleDeltaZ(curStackTransform, deltaZ, curStack.getMaterial());
                else curStack.CreateRubbleDeltaX(curStackTransform, deltaX, curStack.getMaterial());

                curStack.Resize(new Vector3(xpos, curStackTransform.position.y, zpos), new Vector3(GameState.StackBounds.x, curStackTransform.localScale.y, GameState.StackBounds.y));

                
                if(GameState.ZStackMove) GameState.ReverseStackMove();
                GameState.StackMoveZ();
                
                this._stackComponents.Add(_stackFactory.CreateMoveableStack(new Vector3(GameState.BOUNDARY, GameState.CurrentCubeHeight, 0), false, GameState.getPrevStackLocalScale()));
                
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, GameState.CurrentCubeHeight + 0.7f, Camera.main.transform.position.z);

                //Camera.main.transform.position = CameraUtil.setHeight(Camera.main, GameState.CurrentCubeHeight);
            }


        });


    }
}