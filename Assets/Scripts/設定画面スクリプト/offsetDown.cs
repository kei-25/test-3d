using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offsetDown : MonoBehaviour
{
    private int clickCount = 0;

    private void OnMouseDown()
    {
        SettingManager.Offset--;
    }
}