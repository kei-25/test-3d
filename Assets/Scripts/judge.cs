using System;
using UnityEngine;
using TMPro;//new!!
//using System.Diagnostics;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;


public class Judge : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;
    [SerializeField] NotesManager notesManager;

    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI maxcomboText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI perfectText;
    [SerializeField] private TextMeshProUGUI greatText;
    [SerializeField] private TextMeshProUGUI goodText;
    [SerializeField] private TextMeshProUGUI missText;



    AudioSource audio;
    //private AudioSource audioSource;
    //public string soundResourcePath = "SEtemp/Clap";
    [SerializeField] AudioClip hitSound;
    float lastTime = 0;
    bool NoteFlag = true;
    bool NoteLFlag = true;
    bool NoteFFlag = true;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        maxcomboText.text = "0";
        perfectText.text = "0";
        greatText.text = "0";
        goodText.text = "0";
        missText.text = "0";
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = Resources.Load<AudioClip>(soundResourcePath);
    }
    int tempCombmax = 0;
    int tempcomb;
    bool longNoteflag0 = false;
    bool longNoteflag1 = false;
    bool longNoteflag2 = false;
    bool longNoteflag3 = false;

    float TimeLagMiss = 0.23f;
    float tempTimeLag = 0;

    bool flag = false;
    bool timeFlag = false;
    float time;

    public static int combo;
    public static int maxcombo;
    public static int score;
    public static int perfect;
    public static int great;
    public static int good;
    public static int miss;

    float NotelastTime;
    float NotelastTimeL;
    float NotelastTimeF;
    void Update()
    {

        if(!flag)
        {
            if (notesManager.NotesTime.Count == 0)
            {
                NoteFlag = false;
            }
            if (notesManager.NotesTimeL.Count == 0)
            {
                NoteLFlag = false;
            }
            if (notesManager.NotesTimeF.Count == 0)
            {
                NoteFFlag = false;
            }

            if (NoteFlag)
            {
                NotelastTime = notesManager.NotesTime[notesManager.NotesTime.Count - 1];
            }
            else
            {
                NotelastTime = 0;
            }
            if (NoteLFlag)
            {
                NotelastTimeL = notesManager.NotesTimeL[notesManager.NotesTimeL.Count - 1];
            }
            else
            {
                NotelastTimeL = 0;
            }
            if (NoteFFlag)
            {
                NotelastTimeF = notesManager.NotesTimeF[notesManager.NotesTimeF.Count - 1];
            }
            else
            {
                NotelastTimeF = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                if (NotelastTime > NotelastTimeL)
                {
                    lastTime = NotelastTime;
                }
                else
                {
                    lastTime = NotelastTimeL;
                }
                if (NotelastTimeF > lastTime)
                {
                    lastTime = NotelastTimeF;
                }
            }
            Debug.Log(NotelastTime + " " + NotelastTimeL + " " + NotelastTimeF + " " + lastTime);
            flag = true;
        }
        if (GManager.instance.Start)
        {
            time += Time.deltaTime;
            if (time > lastTime + 0.4f && !timeFlag)
            {
                combo = GManager.instance.combo;
                maxcombo = GManager.instance.maxCombo;
                score = GManager.instance.score;
                perfect = GManager.instance.perfect;
                great = GManager.instance.great;
                good = GManager.instance.bad;
                miss = GManager.instance.miss;

                timeFlag = true;
                Thread.Sleep(1000);
                SceneManager.LoadScene("result Scene");
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                longNoteflag0 = false;
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                longNoteflag1 = false;
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                longNoteflag2 = false;
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                longNoteflag3 = false;
            }

            if (notesManager.NotesTime.Count != 0)
            {
                tempTimeLag = GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                longNoteflag0 = true;
                if (notesManager.LaneNum[0] == 0 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else if (notesManager.LaneNum[1] == 0 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 1);
                }
                else if (notesManager.LaneNum[2] == 0 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 2);
                }
                else if (notesManager.LaneNum[3] == 0 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 3);
                }


                else

                {
                    if (notesManager.LaneNum[1] == 0 && notesManager.NoteNum[0] == notesManager.NoteNum[1] && tempTimeLag <= TimeLagMiss)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                longNoteflag1 = true;
                if (notesManager.LaneNum[0] == 1 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else if (notesManager.LaneNum[1] == 1 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 1);
                }
                else if (notesManager.LaneNum[2] == 1 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 2);
                }
                else if (notesManager.LaneNum[3] == 1 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 3);
                }


                else
                {
                    if (notesManager.LaneNum[1] == 1 && notesManager.NoteNum[0] == notesManager.NoteNum[1] && tempTimeLag <= TimeLagMiss)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                longNoteflag2 = true;
                if (notesManager.LaneNum[0] == 2 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else if (notesManager.LaneNum[1] == 2 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 1);
                }
                else if (notesManager.LaneNum[2] == 2 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 2);
                }
                else if (notesManager.LaneNum[3] == 2 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 3);
                }


                else
                {
                    if (notesManager.LaneNum[1] == 2 && notesManager.NoteNum[0] == notesManager.NoteNum[1] && tempTimeLag <= TimeLagMiss)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                longNoteflag3 = true;
                if (notesManager.LaneNum[0] == 3 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else if (notesManager.LaneNum[1] == 3 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 1);
                }
                else if (notesManager.LaneNum[2] == 3 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 2);
                }
                else if (notesManager.LaneNum[3] == 3 && tempTimeLag <= TimeLagMiss)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 3);
                }


                else
                {
                    if (notesManager.LaneNum[1] == 3 && notesManager.NoteNum[0] == notesManager.NoteNum[1] && tempTimeLag <= TimeLagMiss)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }


            if (longNoteflag0)
            {
                for (int i = 0; i < notesManager.NotesTimeL.Count; i++)
                {
                    if (Time.time > notesManager.NotesTimeL[i] + 0.0f + GManager.instance.StartTime && notesManager.LaneNumL[i] == 0)
                    {
                        GManager.instance.ratioScore += 5;
                        GManager.instance.perfect++;
                        GManager.instance.combo++;

                        messageL(i);
                        deleteDataL(i);
                        Debug.Log("Perfect");
                        break;
                    }
                }
            }

            if (longNoteflag1)
            {
                for (int i = 0; i < notesManager.NotesTimeL.Count; i++)
                {
                    if (Time.time > notesManager.NotesTimeL[i] + 0.0f + GManager.instance.StartTime && notesManager.LaneNumL[i] == 1)
                    {
                        GManager.instance.ratioScore += 5;
                        GManager.instance.perfect++;
                        GManager.instance.combo++;

                        messageL(i);
                        deleteDataL(i);
                        Debug.Log("Perfect");
                        break;
                    }
                }
            }

            if (longNoteflag2)
            {
                for (int i = 0; i < notesManager.NotesTimeL.Count; i++)
                {
                    if (Time.time > notesManager.NotesTimeL[i] + 0.0f + GManager.instance.StartTime && notesManager.LaneNumL[i] == 2)
                    {
                        GManager.instance.ratioScore += 5;
                        GManager.instance.perfect++;
                        GManager.instance.combo++;

                        messageL(i);
                        deleteDataL(i);
                        Debug.Log("Perfect");
                        break;
                    }
                }
            }

            if (longNoteflag3)
            {
                for (int i = 0; i < notesManager.NotesTimeL.Count; i++)
                {
                    if (Time.time > notesManager.NotesTimeL[i] + 0.0f + GManager.instance.StartTime && notesManager.LaneNumL[i] == 3)
                    {
                        GManager.instance.ratioScore += 5;
                        GManager.instance.perfect++;
                        GManager.instance.combo++;

                        messageL(i);
                        deleteDataL(i);
                        Debug.Log("Perfect");
                        break;
                    }
                }
            }


            //float p = notesManager.NotesTimeL[0] + 0.1f + GManager.instance.StartTime;
            //Debug.Log(longNoteflag0+"A"+longNoteflag1 + "A" + longNoteflag2 + "A" + longNoteflag3);
            if (notesManager.NotesTimeL.Count != 0)
            {
                for (int i = 0; i < notesManager.NotesTimeL.Count; i++)
                {
                    if (Time.time > notesManager.NotesTimeL[i] + 0.1f + GManager.instance.StartTime)
                    {
                        messageLM(i);
                        deleteDataL(i);
                        Debug.Log("Miss");
                        GManager.instance.miss++;
                        GManager.instance.combo = 0;
                        //GManager.instance.ratioScore += 5;
                    }
                }
            }
            if (notesManager.NotesTime.Count != 0)
            {
                if (Time.time > notesManager.NotesTime[0] + 0.1f + GManager.instance.StartTime)//本来ノーツをたたくべき時間から0.1秒たっても入力がなかった場合
                {
                    message(3);
                    deleteData(0);
                    Debug.Log("Miss");
                    GManager.instance.miss++;
                    GManager.instance.combo = 0;
                    //GManager.instance.ratioScore += 5;
                }
            }

            /*
            if (notesManager.NotesTimeL.Count != 0)
            {
                if (Time.time > notesManager.NotesTimeL[0] + 0f + GManager.instance.StartTime)
                {
                    messageL(0);
                    deleteDataL(0);
                    GManager.instance.ratioScore += 5;
                    GManager.instance.perfect++;
                    GManager.instance.combo++;
                }
            }
            if (notesManager.NotesTime.Count != 0)
            {
                if (Time.time > notesManager.NotesTime[0] + 0f + GManager.instance.StartTime)//本来ノーツをたたくべき時間から0.1秒たっても入力がなかった場合
                {
                    message(0);
                    deleteData(0);
                    GManager.instance.ratioScore += 5;
                    GManager.instance.perfect++;
                    GManager.instance.combo++;
                }
            }*/
        }
    }
    


    void Judgement(float timeLag, int numOffset)
    {
        
        if (timeLag <= 0.06)
        {
            Debug.Log("Perfect");
            audio.PlayOneShot(hitSound);
            //audioSource.Play();
            message(0);
            GManager.instance.ratioScore += 5;
            GManager.instance.perfect++;
            GManager.instance.combo++;
            deleteData(numOffset);
        }
        else
        {
            if (timeLag <= 0.09)
            {
                Debug.Log("Great");
                audio.PlayOneShot(hitSound);
                message(1);
                GManager.instance.ratioScore += 3;
                GManager.instance.great++;
                GManager.instance.combo++;
                deleteData(numOffset);
            }
            else
            {
                if (timeLag <= 0.11)
                {
                    Debug.Log("Bad");
                    message(2);
                    GManager.instance.ratioScore += 1;
                    GManager.instance.bad++;
                    GManager.instance.combo = 0;
                    deleteData(numOffset);
                }
                else
                {
                    if (timeLag > 0.11)
                    {
                        message(3);
                        Debug.Log("Miss");
                        GManager.instance.miss++;
                        GManager.instance.combo = 0;
                        deleteData(numOffset);
                    }
                }
            } 
        }
    }
    float GetABS(float num)
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }

    void deleteData(int numOffset)
    {
        //NotesManager notesManager = this.notesManager; // notesManager変数を使ってNotesManagerのインスタンスを取得
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        notesManager.NoteNum.RemoveAt(numOffset);
        //notesManager.NotesObj.RemoveAt(numOffset);
        //GameObject firstGameObject = notesManager.NotesObj[numOffset];
        Destroy(notesManager.NotesObj[numOffset]);
        notesManager.NotesObj.Remove(notesManager.NotesObj[numOffset]);
        
        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);


        tempcomb = GManager.instance.combo;
        if (tempcomb > tempCombmax)
        {
            //Debug.Log(GManager.instance.combo+">"+tempCombmax+"MAX"+ GManager.instance.maxCombo);
            GManager.instance.maxCombo = GManager.instance.combo;
            tempCombmax = GManager.instance.maxCombo;
            maxcomboText.text = tempCombmax.ToString();
        }
        comboText.text = GManager.instance.combo.ToString();
        scoreText.text = GManager.instance.score.ToString();
        perfectText.text = GManager.instance.perfect.ToString();
        greatText.text = GManager.instance.great.ToString();
        goodText.text = GManager.instance.bad.ToString();
        missText.text = GManager.instance.miss.ToString();

    }

    public void deleteDataF(int numOffset)
    {
        //NotesManager notesManager = this.notesManager; // notesManager変数を使ってNotesManagerのインスタンスを取得
        notesManager.NotesTimeF.RemoveAt(numOffset);
        notesManager.LaneNumF.RemoveAt(numOffset);
        notesManager.NoteTypeF.RemoveAt(numOffset);
        notesManager.NoteNumF.RemoveAt(numOffset);
        Destroy(notesManager.NotesObjF[numOffset]);          
        notesManager.NotesObjF.Remove(notesManager.NotesObjF[numOffset]);  

        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);


        tempcomb = GManager.instance.combo;
        if (tempcomb > tempCombmax)
        {
            //Debug.Log(GManager.instance.combo+">"+tempCombmax+"MAX"+ GManager.instance.maxCombo);
            GManager.instance.maxCombo = GManager.instance.combo;
            tempCombmax = GManager.instance.maxCombo;
            maxcomboText.text = tempCombmax.ToString();
        }
        comboText.text = GManager.instance.combo.ToString();
        scoreText.text = GManager.instance.score.ToString();
        perfectText.text = GManager.instance.perfect.ToString();
        greatText.text = GManager.instance.great.ToString();
        goodText.text = GManager.instance.bad.ToString();
        missText.text = GManager.instance.miss.ToString();
    }

    public void deleteDataL(int numOffset)
    {
        //NotesManager notesManager = this.notesManager; // notesManager変数を使ってNotesManagerのインスタンスを取得
        notesManager.NotesTimeL.RemoveAt(numOffset);
        notesManager.LaneNumL.RemoveAt(numOffset);
        notesManager.NoteNumL.RemoveAt(numOffset);

        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);

        tempcomb = GManager.instance.combo;
        if (tempcomb > tempCombmax)
        {
            //Debug.Log(GManager.instance.combo+">"+tempCombmax+"MAX"+ GManager.instance.maxCombo);
            GManager.instance.maxCombo = GManager.instance.combo;
            tempCombmax = GManager.instance.maxCombo;
            maxcomboText.text = tempCombmax.ToString();
        }
        comboText.text = GManager.instance.combo.ToString();
        scoreText.text = GManager.instance.score.ToString();
        perfectText.text = GManager.instance.perfect.ToString();
        greatText.text = GManager.instance.great.ToString();
        goodText.text = GManager.instance.bad.ToString();
        missText.text = GManager.instance.miss.ToString();
    }


    void message(int judge)
    {
        Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
    void messageL(int i)
    {
        Instantiate(MessageObj[0], new Vector3(notesManager.LaneNumL[i] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
    void messageLM(int i)
    {
        Instantiate(MessageObj[3], new Vector3(notesManager.LaneNumL[i] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
    public static (int,int, int, int, int, int, int) GetNum()
    {
        return (combo,maxcombo,score,perfect,great,good,miss);
    }
}
