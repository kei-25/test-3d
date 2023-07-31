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
    public Note[] notes;

}
[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
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
    public List<GameObject> NotesObjF = new List<GameObject>();

    private float NotesSpeed;
    [SerializeField] GameObject noteObj;
    [SerializeField] GameObject noteObjFlick;

    void Start()
    {
        NotesSpeed = GManager.instance.noteSpeed;
        noteNum = 0;
        songName = "Danger";
        songNameFlick = "Danger - ÉRÉsÅ[";
        Load(songName, songNameFlick);
    }

    private void Load(string SongName, string songNameFlick)
    {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        

        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            //GmanagerÇÃnoteSpeedÇ…ÇÊÇ¡ÇƒÉmÅ[ÉcÇÃä‘äuÇåàíËÇ∑ÇÈ
            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset * 0.01f;
            NotesTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            NoteType.Add(inputJson.notes[i].type);
            NoteNum.Add(inputJson.notes[i].num);

            float z = NotesTime[i] * NotesSpeed;
            /*if (inputJson.notes[i].type == 1)
            {*/
                NotesObj.Add(Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 1.5f, 0.5f, z), Quaternion.identity));
            /*}
            else
            {

            }*/
        }

        string inputStringFlick = Resources.Load<TextAsset>(songNameFlick).ToString();
        Data inputJsonFlick = JsonUtility.FromJson<Data>(inputStringFlick);

        noteNumFlick = inputJsonFlick.notes.Length;
        noteNum = inputJson.notes.Length;
        noteNumSum = noteNum + noteNumFlick;
        GManager.instance.maxScore = noteNumSum * 5;//new!!

        for (int j = 0; j < inputJsonFlick.notes.Length; j++)
        {
            //GmanagerÇÃnoteSpeedÇ…ÇÊÇ¡ÇƒÉmÅ[ÉcÇÃä‘äuÇåàíËÇ∑ÇÈ
            float kankaku = 60 / (inputJsonFlick.BPM * (float)inputJsonFlick.notes[j].LPB);
            float beatSec = kankaku * (float)inputJsonFlick.notes[j].LPB;
            float time = (beatSec * inputJsonFlick.notes[j].num / (float)inputJsonFlick.notes[j].LPB) + inputJsonFlick.offset * 0.01f;
            NotesTimeF.Add(time);
            LaneNumF.Add(inputJsonFlick.notes[j].block);
            NoteTypeF.Add(inputJsonFlick.notes[j].type);
            NoteNumF.Add(inputJsonFlick.notes[j].num);
            float x = inputJsonFlick.notes[j].block *0.5f;
            float z = NotesTimeF[j] * NotesSpeed;
            Debug.Log(x - 1.75);
            NotesObjF.Add(Instantiate(noteObjFlick, new Vector3(x - 1.75f, 0.5f, z), Quaternion.identity));

        }
    }

}