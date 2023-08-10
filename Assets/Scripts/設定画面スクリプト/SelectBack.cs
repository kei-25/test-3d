using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBack : MonoBehaviour
{

    private void OnMouseDown()
    {
        SceneManager.LoadScene("selectSongScene");
    }
}
