using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public sounds[] sound;
    // Start is called before the first frame update
    public static AudioManager instance;
    void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach( sounds s in sound){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume  = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    void Start(){
       playsound("ThemeMusic");
    }

    // Update is called once per frame
     
     public void playsound(string name){
        sounds s=  Array.Find(sound, sounds => sounds.name == name);
        s.source.Play();
        Debug.Log("Audio is playing");
     }
}
