using System;
using UnityEngine;
using TMPro;//new!!
//using System.Diagnostics;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数

    [SerializeField] private TextMeshProUGUI comboText;//new!!
    [SerializeField] private TextMeshProUGUI scoreText;//new!!



    AudioSource audio;
    [SerializeField] AudioClip hitSound;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GManager.instance.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))//〇キーが押されたとき
            {
                if (notesManager.LaneNum[0] == 0)//押されたボタンはレーンの番号とあっているか？
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }


                else if (notesManager.LaneNum[1] == 0)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 1);
                }
                else if (notesManager.LaneNum[2] == 0)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 2);
                }
                else if (notesManager.LaneNum[3] == 0)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 3);
                }


                else

                {
                    if (notesManager.LaneNum[1] == 0 && notesManager.NoteNum[0] == notesManager.NoteNum[1])
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (notesManager.LaneNum[0] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }


                else if (notesManager.LaneNum[1] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 1);
                }
                else if (notesManager.LaneNum[2] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 2);
                }
                else if (notesManager.LaneNum[3] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 3);
                }


                else
                {
                    if (notesManager.LaneNum[1] == 1 && notesManager.NoteNum[0] == notesManager.NoteNum[1])
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (notesManager.LaneNum[0] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }


                else if (notesManager.LaneNum[1] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 1);
                }
                else if (notesManager.LaneNum[2] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 2);
                }
                else if (notesManager.LaneNum[3] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 3);
                }


                else
                {
                    if (notesManager.LaneNum[1] == 2 && notesManager.NoteNum[0] == notesManager.NoteNum[1])
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (notesManager.LaneNum[0] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }


                else if (notesManager.LaneNum[1] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 1);
                }
                else if (notesManager.LaneNum[2] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 2);
                }
                else if (notesManager.LaneNum[3] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 3);
                }


                else
                {
                    if (notesManager.LaneNum[1] == 3 && notesManager.NoteNum[0] == notesManager.NoteNum[1])
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            if (Time.time > notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
            {
                message(3);
                deleteData(0);
                Debug.Log("Miss");
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                //GManager.instance.ratioScore += 5;
                //ミス
            }
        
        }

    }
    


    void Judgement(float timeLag, int numOffset)
    {
        audio.PlayOneShot(hitSound);
        if (timeLag <= 0.05)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            Debug.Log("Perfect");
            message(0);
            GManager.instance.ratioScore += 5;//new!!
            GManager.instance.perfect++;
            GManager.instance.combo++;
            deleteData(numOffset);
        }
        else
        {
            if (timeLag <= 0.08)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                Debug.Log("Great");
                message(1);
                GManager.instance.ratioScore += 3;//new!!
                GManager.instance.great++;
                GManager.instance.combo++;
                deleteData(numOffset);
            }
            else
            {
                if (timeLag <= 0.10)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    Debug.Log("Bad");
                    message(2);
                    GManager.instance.ratioScore += 1;//new!!
                    GManager.instance.bad++;
                    GManager.instance.combo = 0;
                    deleteData(numOffset);
                }
            }
        }
    }
    float GetABS(float num)//引数の絶対値を返す関数
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

    void deleteData(int numOffset)//すでにたたいたノーツを削除する関数
    {
        //NotesManager notesManager = this.notesManager; // notesManager変数を使ってNotesManagerのインスタンスを取得
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        notesManager.NoteNum.RemoveAt(numOffset);
        //notesManager.NotesObj.RemoveAt(numOffset);
        //GameObject firstGameObject = notesManager.NotesObj[numOffset];
        Destroy(notesManager.NotesObj[numOffset]);          // オブジェクトをシーンから削除
        notesManager.NotesObj.Remove(notesManager.NotesObj[numOffset]);  // リストからオブジェクトを削除
        
        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);
        //↑new!!

        comboText.text = GManager.instance.combo.ToString();//new!!
        scoreText.text = GManager.instance.score.ToString();//new!!

    }

    public void deleteDataF(int numOffset)//すでにたたいたノーツを削除する関数
    {
        //NotesManager notesManager = this.notesManager; // notesManager変数を使ってNotesManagerのインスタンスを取得
        notesManager.NotesTimeF.RemoveAt(numOffset);
        notesManager.LaneNumF.RemoveAt(numOffset);
        notesManager.NoteTypeF.RemoveAt(numOffset);
        notesManager.NoteNumF.RemoveAt(numOffset);
        Destroy(notesManager.NotesObjF[numOffset]);          // オブジェクトをシーンから削除
        notesManager.NotesObjF.Remove(notesManager.NotesObjF[numOffset]);  // リストからオブジェクトを削除

        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);
        //↑new!!

        comboText.text = GManager.instance.combo.ToString();//new!!
        scoreText.text = GManager.instance.score.ToString();//new!!

    }

    void message(int judge)//判定を表示する
    {
        Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }

}
