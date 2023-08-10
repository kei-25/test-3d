using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    private int clickCount = 0;

    private void OnMouseDown()
    {
        SettingManager.NoteSpeed++;
        Debug.Log("Click Count: " + clickCount);
    }
}
