using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offsetUp : MonoBehaviour
{
    private int clickCount = 0;

    private void OnMouseDown()
    {
        SettingManager.Offset++;
        Debug.Log("Click Count: " + clickCount);
    }
}