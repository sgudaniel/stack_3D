using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounterFactory
{
    public ScoreCounterComponent Create(Vector3 position, Quaternion rotation)
    {
        var scorecounter = GameObject.Instantiate(PrefabResolver.ScoreCounterPrefab, position, rotation);
        var scorecounterComponent  = scorecounter.AddComponent<ScoreCounterComponent>();

        return scorecounterComponent;
    }
}
