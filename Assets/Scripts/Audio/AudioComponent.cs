using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioComponent : MonoBehaviour
{
    private AudioSource _audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        this._audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    public void Stop(){
        this.gameObject.GetComponent<AudioSource>().Stop();
    }
}
