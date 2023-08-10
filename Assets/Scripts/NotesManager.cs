//ÉmÅ[ÉcÇ™ó¨ÇÍÇƒÇ≠ÇÈÇÃÇ™íxÇØÇÍÇŒoffsetÇè¨Ç≥Ç≠ÇµÅAëÅÇØÇÍÇŒëÂÇ´Ç≠Ç∑ÇÈ

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes, longNotes;
}
[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
    public Note[] notes;
}

public class NotesManager : MonoBehaviour
{
    public int noteNum;
    public int noteNumFlick;
    public int noteNumSum;
    private string songName;
    private string songNameFlick;

    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<int> NoteNum = new List<int>();
    public List<GameObject> NotesObj = new List<GameObject>();

    public List<int> LaneNumF = new List<int>();
    public List<int> NoteTypeF = new List<int>();
    public List<float> NotesTimeF = new List<float>();
    public List<int> NoteNumF = new List<int>();

    public List<int> LaneNumL = new List<int>();
    public List<float> NotesTimeL = new List<float>();
    public List<int> NoteNumL = new List<int>();

    public List<GameObject> NotesObjF = new List<GameObject>();
    public List<GameObject> NotesObjL = new List<GameObject>();

    private float NotesSpeed;

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
    public Note tempList;

    [SerializeField] GameObject noteObj;
    [SerializeField] GameObject noteObjFlick;
    [SerializeField] GameObject noteObjLong;
    int SelectSongNum = SpawnClones.GetSelectSong();
    int DifficultyNum = difficultyColour.GetDifficultyNum();
    string difficlty;

    float settingOffset;
    void Start()
    {
        switch (DifficultyNum)
        {
            case 0:
                difficlty = "EZ";
                break;
            case 1:
                difficlty = "H";
                break;
            case 2:
                difficlty = "E";
                break;
            case 3:
                difficlty = "M";
                break;
        }
        var tempNoteSpeed = SettingManager.GetNum();
        settingOffset = tempNoteSpeed.Item2;

        LoadJson("seetMusicSelect");
        NotesSpeed = GManager.instance.noteSpeed;
        noteNum = 0;
        string Noteseet = inputJsonSong.selectList[SelectSongNum].songName + difficlty;
        songName = Noteseet;
        string FlickSeetName = Noteseet + "F";
        Debug.Log(Noteseet+" "+FlickSeetName);
        songNameFlick = FlickSeetName;
        songName = "seetMusic/" + songName;
        songNameFlick = "seetMusic/" + songNameFlick;
        Load(songName, songNameFlick);
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

        private void Load(string SongName, string songNameFlick)
    {
        float z;
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        float tempOffset = inputJson.offset + settingOffset;
        int soeziL = 0;
        for (int i = 0; i < inputJson.notes.Length; i++)
        {

            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + tempOffset * 0.01f;
          
            z = time * NotesSpeed;


            /*if (inputJson.notes[i].type == 1)
            {*/
                NotesTime.Add(time);
                LaneNum.Add(inputJson.notes[i].block);
                NoteType.Add(inputJson.notes[i].type);
                NoteNum.Add(inputJson.notes[i].num);
                NotesObj.Add(Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 1.5f, 0.5f, z), Quaternion.identity));
            //}
        }

        string inputStringFlick = Resources.Load<TextAsset>(songNameFlick).ToString();
        Data inputJsonFlick = JsonUtility.FromJson<Data>(inputStringFlick);

        noteNumFlick = inputJsonFlick.notes.Length;
        noteNum = inputJson.notes.Length;
        noteNumSum = noteNum + noteNumFlick;

        float tempOffsetF = inputJsonFlick.offset + settingOffset;
        for (int j = 0; j < inputJsonFlick.notes.Length; j++)
        {
            float kankaku = 60 / (inputJsonFlick.BPM * (float)inputJsonFlick.notes[j].LPB);
            float beatSec = kankaku * (float)inputJsonFlick.notes[j].LPB;
            float time = (beatSec * inputJsonFlick.notes[j].num / (float)inputJsonFlick.notes[j].LPB) + tempOffset * 0.01f;
            NotesTimeF.Add(time);
            LaneNumF.Add(inputJsonFlick.notes[j].block);
            NoteTypeF.Add(inputJsonFlick.notes[j].type);
            NoteNumF.Add(inputJsonFlick.notes[j].num);
            float x = inputJsonFlick.notes[j].block *0.5f;
            float zz = NotesTimeF[j] * NotesSpeed;
            //Debug.Log(x - 1.75);
            NotesObjF.Add(Instantiate(noteObjFlick, new Vector3(x - 1.75f, 0.5f, zz), Quaternion.identity));

        }

        float kankakuT;
        float beatSecT;
        float timeT;
        float tempZ;

        for (int j = 0; j < inputJson.notes.Length; j++)
        {
            //Debug.Log(j+" "+ inputJson.notes[j].type);
            if (inputJson.notes[j].type == 2)
            {
                float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[j].LPB);
                float beatSec = kankaku * (float)inputJson.notes[j].LPB;
                float time = (beatSec * inputJson.notes[j].num / (float)inputJson.notes[j].LPB) + tempOffset * 0.01f;
                z = time * NotesSpeed;

                Note[] longNoteList = inputJson.notes[j].notes;
                int tempNum = longNoteList[0].num;
                kankakuT = 60 / (inputJson.BPM * (float)inputJson.notes[j].LPB);
                beatSecT = kankakuT * (float)inputJson.notes[j].LPB;
                timeT = (beatSecT * tempNum / (float)inputJson.notes[j].LPB) + tempOffset * 0.01f;
                tempZ = timeT * NotesSpeed;

                float scaleZ = tempZ - z;
                float lnv3z = (tempZ + z) / 2;
                
                NotesObjL.Add(Instantiate(noteObjLong, new Vector3(inputJson.notes[j].block - 1.5f, 0.48f, lnv3z), Quaternion.identity));
                NotesObjL[soeziL].transform.localScale = new Vector3(1, 0.05f, scaleZ);
                soeziL = soeziL + 1;
                int lninterval = tempNum - inputJson.notes[j].num-1;
                for (int k = 0; k <lninterval ; k++)
                {
                    if (k % 2 == 0)
                    {
                        int tempNumL = inputJson.notes[j].num + k;
                        float kankakuL = 60 / (inputJson.BPM * (float)inputJson.notes[j].LPB);
                        float beatSecL = kankakuL * (float)inputJson.notes[j].LPB;
                        float timeL = (beatSecL * tempNumL / (float)inputJson.notes[j].LPB) + tempOffset * 0.01f;
                        NotesTimeL.Add(timeL);
                        LaneNumL.Add(inputJson.notes[j].block);
                        NoteNumL.Add(tempNumL);
                    }
                }
            }
        }
        /*
        for (int u = 0; u < 9; u++)
        {
            Debug.Log(NoteNumL[u] + "AAAAAAA");
        }*/
        noteNumSum = noteNumSum + NoteNumL.Count;
        GManager.instance.maxScore = noteNumSum * 5;
    }

}