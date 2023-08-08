using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    [SerializeField] GameObject gameObjectScore;
    [SerializeField] GameObject gameObjectCombo;
    [SerializeField] GameObject gameObjectPerfect;
    [SerializeField] GameObject gameObjectGreat;
    [SerializeField] GameObject gameObjectGood;
    [SerializeField] GameObject gameObjectMiss;

    void Start()
    {
        var num = Judge.GetNum();
        ResultS(num.Item3,num.Item2, num.Item4, num.Item5, num.Item6, num.Item7);
        flag = true;
    }

    void ResultS(int score,int combo,int perfect,int great,int good,int miss)
    {
        Transform scoreTransform = gameObjectScore.transform;
        TextMeshPro scoretextMeshPro = scoreTransform.GetComponent<TextMeshPro>();
        Transform comboTransform = gameObjectCombo.transform;
        TextMeshPro combotextMeshPro = comboTransform.GetComponent<TextMeshPro>();
        Transform perfectTransform = gameObjectPerfect.transform;
        TextMeshPro PerfecttextMeshPro = perfectTransform.GetComponent<TextMeshPro>();
        Transform greatTransform = gameObjectGreat.transform;
        TextMeshPro greattextMeshPro = greatTransform.GetComponent<TextMeshPro>();
        Transform goodTransform = gameObjectGood.transform;
        TextMeshPro goodtextMeshPro = goodTransform.GetComponent<TextMeshPro>();
        Transform missTransform = gameObjectMiss.transform;
        TextMeshPro misstextMeshPro = missTransform.GetComponent<TextMeshPro>();

        scoretextMeshPro.text = score.ToString();
        combotextMeshPro.text = combo.ToString();
        PerfecttextMeshPro.text = perfect.ToString();
        greattextMeshPro.text = great.ToString();
        goodtextMeshPro.text = good.ToString();
        misstextMeshPro.text = miss.ToString();
    }
    bool flag = false;
    float time;
    float SetTime = 2f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("selectSongDisplay");
        }
    }
}
