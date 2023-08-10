using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class MusicManager : MonoBehaviour
{
    AudioSource musicaudio;
    AudioClip Music;
    string songName;
    bool played;

    public DataB inputJsonSong;
    public class DataB
    {
        public songSelect[] selectList;
    }
    [System.Serializable]
    public class songSelect
    {
        public string songName;
        public int difficultyEasy;
        public int difficultyHard;
        public int difficultyExpert;
        public int difficultyMaster;
    }

    int SelectSongNum = SpawnClones.GetSelectSong();
    void Start()
    {
        LoadJson("seetMusicSelect");
        songName = inputJsonSong.selectList[SelectSongNum].songName;
        played = false;
        Debug.Log("Loaded AudioClip: " + Music.name);
    }

    private void LoadJson(string songselect)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(songselect);
        if (textAsset != null)
        {
            inputJsonSong = JsonUtility.FromJson<DataB>(textAsset.ToString());
        }
        else
        {
            Debug.LogError("Failed to load JSON file: " + songselect);
        }
    }


    // Update is called once per frame
    float elapsedTime = 0f;
    public float SetTime = 0.1f;
    void Update()
    {
        if (!played)
        {
            elapsedTime += Time.deltaTime;
        }
        if (elapsedTime > SetTime && !played)
        {
            GManager.instance.Start = true;
            GManager.instance.StartTime = Time.time;
            GManager.instance.startFlag = true;
            played = true;
            StartCoroutine(PlayMusic());
        }
    }

    IEnumerator PlayMusic()
    {
        AudioClip musicClip = Resources.Load<AudioClip>("Musics/" + songName);

        if (musicClip != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = musicClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Failed to load music file.");
        }

        yield return null;
    }
}