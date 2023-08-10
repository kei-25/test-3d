using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingManager : MonoBehaviour
{
    [SerializeField] GameObject gameObjectNoteSpeed;
    [SerializeField] GameObject gameObjectOffset;
    public static int NoteSpeed = 1;
    public static float Offset = 0;
    int tempNoteSpeed = NoteSpeed;
    float tempOffset = Offset;
    void Start()
    {
        Transform noteSpeedTransform = gameObjectNoteSpeed.transform;
        TextMeshPro noteSpeedtextMeshPro = noteSpeedTransform.GetComponent<TextMeshPro>();
        noteSpeedtextMeshPro.text = tempNoteSpeed.ToString();

        Transform OffsetTransform = gameObjectOffset.transform;
        TextMeshPro OffsettextMeshPro = OffsetTransform.GetComponent<TextMeshPro>();
        OffsettextMeshPro.text = tempOffset.ToString();
    }


    void Update()
    {
        if (tempNoteSpeed != NoteSpeed)
        {
            tempNoteSpeed = NoteSpeed;
            Transform noteSpeedTransform = gameObjectNoteSpeed.transform;
            TextMeshPro noteSpeedtextMeshPro = noteSpeedTransform.GetComponent<TextMeshPro>();
            noteSpeedtextMeshPro.text = tempNoteSpeed.ToString();
        }
        if (tempOffset != Offset)
        {
            tempOffset = Offset;
            Transform OffsetTransform = gameObjectOffset.transform;
            TextMeshPro OffsettextMeshPro = OffsetTransform.GetComponent<TextMeshPro>();
            OffsettextMeshPro.text = tempOffset.ToString();
        }
    }
    public static (int,float)GetNum()
    {
        return (NoteSpeed,Offset);
    }
}
