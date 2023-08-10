using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    float NoteSpeed = 8;
    bool start;

    void Start()
    {
        NoteSpeed = GManager.instance.noteSpeed;
    }
    void Update()
    {
        if (GManager.instance.startFlag)
        {
            start = true;
        }
        if (start)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeed;
        }
    }
}