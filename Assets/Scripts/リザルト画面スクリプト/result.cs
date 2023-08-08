using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    [SerializeField] GameObject gameObjectRank;
    [SerializeField] GameObject gameObjectScore;
    [SerializeField] GameObject gameObjectCombo;
    [SerializeField] GameObject gameObjectPerfect;
    [SerializeField] GameObject gameObjectGreat;
    [SerializeField] GameObject gameObjectGood;
    [SerializeField] GameObject gameObjectMiss;
    string rankText = "";

    void Start()
    {
        var num = Judge.GetNum();
        ResultS(num.Item3,num.Item2, num.Item4, num.Item5, num.Item6, num.Item7);
        flag = true;
    }

    void ResultS(int score,int combo,int perfect,int great,int good,int miss)
    {
        if(score >=990000)
        {
            rankText = "SSS";
        }
        else if(score >= 975000)
        {
            rankText = "SS";
        }
        else if (score >= 960000)
        {
            rankText = "S";
        }
        else if (score >= 940000)
        {
            rankText = "AAA";
        }
        else if (score >= 910000)
        {
            rankText = "AA";
        }
        else if (score >= 880000)
        {
            rankText = "A";
        }
        else if (score >= 800000)
        {
            rankText = "BBB";
        }
        else if (score >= 720000)
        {
            rankText = "BB";
        }
        else if (score >= 660000)
        {
            rankText = "B";
        }
        else if (score >= 550000)
        {
            rankText = "CCC";
        }
        else if (score >= 440000)
        {
            rankText = "CC";
        }
        else if (score >= 3300000)
        {
            rankText = "C";
        }
        else if (score >= 2500000)
        {
            rankText = "DDD";
        }
        else if (score >= 1700000)
        {
            rankText = "DD";
        }
        else if (score <= 1700000)
        {
            rankText = "D";
        }

        Transform rankTransform = gameObjectRank.transform;
        TextMeshPro ranktextMeshPro = rankTransform.GetComponent<TextMeshPro>();
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

        ranktextMeshPro.text = rankText;
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
