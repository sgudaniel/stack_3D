using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using TMPro;

public class ScoreCounterComponent : MonoBehaviour
{
    private Subject<Unit> theSubject;
    private TextMeshProUGUI scoreText;

    public IObservable<Unit> GetObservable
    {
        get
        {
            return this.theSubject.AsObservable();
        }
    }

    ScoreCounterComponent()
    {
        this.theSubject = new Subject<Unit>();
    }

    void Start()
    {
        this.scoreText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Increase()
    {
        int scoreInteger = int.Parse(this.scoreText.text) + 1;
        this.scoreText.text = scoreInteger.ToString();
    }

}
