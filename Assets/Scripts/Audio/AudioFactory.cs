using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFactory
{

    public AudioComponent Create(GameObject prefab)
    {
        var audio = GameObject.Instantiate(prefab);

        var audioSource = audio.AddComponent<AudioSource>();

        var audi = audio.AddComponent<AudioComponent>();
        return audi;

    }
   
}
