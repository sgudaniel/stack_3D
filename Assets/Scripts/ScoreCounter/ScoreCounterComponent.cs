using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using TMPro;

public class ScoreCounterComponent : MonoBehaviour
{
    private Subject<Unit> _theSubject;
    private TextMeshProUGUI _scoreText;

    public IObservable<Unit> GetObservable
    {
        get
        {
            return this._theSubject.AsObservable();
        }
    }

    ScoreCounterComponent()
    {
        this._theSubject = new Subject<Unit>();
    }

    void Start()
    {
        this._scoreText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Increase()
    {
        int scoreInteger = int.Parse(this._scoreText.text) + 1;
        this._scoreText.text = scoreInteger.ToString();
    }

}
