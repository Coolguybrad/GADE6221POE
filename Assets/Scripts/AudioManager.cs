using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource _audio;
    public AudioClip _clip;

    private void Start()
    {
       
    }
    private void Update()
    {
        
    }

    
    public void ReturnAudio() 
    {
        //for later use when audio is implemented
        // (Instant Transmission sound)
        print("Audio is playing");
        _audio.PlayOneShot(_clip);
    }
}
