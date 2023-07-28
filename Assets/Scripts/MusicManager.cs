using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource musicaudio;
    AudioClip Music;
    string songName;
    bool played;

    void Start()
    {
        songName = "OP";
        musicaudio = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;
        Debug.Log("Loaded AudioClip: " + Music.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !played)
        {
            GManager.instance.Start = true;
            GManager.instance.StartTime = Time.time;
            played = true;
            musicaudio.Play();
        }
    }
}