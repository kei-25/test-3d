using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    public bool startFlag = false;

    public float maxScore;
    public float ratioScore;

    public int songID;
    public float noteSpeed;

    public bool Start;
    public float StartTime;

    public int combo;
    public int maxCombo;
    public int score;

    public int perfect;
    public int great;
    public int bad;
    public int miss;

    public void Awake()
    {
        var tempNoteSpeed = SettingManager.GetNum();
        noteSpeed = noteSpeed + tempNoteSpeed.Item1;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}