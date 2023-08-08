using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class flickTest : MonoBehaviour
{
    [SerializeField] private GameObject[] MessageObj;
    [SerializeField] NotesManager notesManager;
    [SerializeField] Judge judge;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            Vector3 mousePosition = Input.mousePosition;
            // カーソル位置のz座標を10に
            mousePosition.z = 10;
            // カーソル位置をワールド座標に変換
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, 103f, 2.8f)); //左220,右880
            // GameObjectのtransform.positionにカーソル位置(ワールド座標)を代入
            if (mousePosition.x > 237 && mousePosition.x < 865)
            {
                transform.position = target;
            }
        if (GManager.instance.Start)
        {
            if (notesManager.NotesTimeF.Count != 0)
            {
                if (Time.time > notesManager.NotesTimeF[0] + 0.1f + GManager.instance.StartTime)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
                {
                    int lane = notesManager.LaneNumF[0];
                    message(lane, 1);
                    Debug.Log("Miss");
                    GManager.instance.miss++;
                    GManager.instance.combo = 0;
                    judge.deleteDataF(0);
                    //GManager.instance.ratioScore += 5;
                    //ミス
                }
            }
        }
    }
    void OnCollisionEnter(Collision hit)
    {
        checkItem(hit.collider.gameObject);
    }

    void checkItem(GameObject obj)
    {
        if (obj.name == "Flick(Clone)")
        {
            
            Vector3 positionF = obj.transform.position;
            float FlickX = (positionF.x + 1.75f) * 2;
            int flickLane = (int)FlickX;
            
            if (flickLane == 0)
            {
                for(int i = 0; i<9; i++)
                {
                    if (notesManager.LaneNumF[i] == 0)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }

            else if (flickLane == 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (notesManager.LaneNumF[i] == 0)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }

            else if (flickLane == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (notesManager.LaneNumF[i] == 1)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }

            else if (flickLane == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (notesManager.LaneNumF[i] == 2)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }

            else if (flickLane == 3)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (notesManager.LaneNumF[i] == 3)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }

            else if (flickLane == 4)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (notesManager.LaneNumF[i] == 4)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }

            else if (flickLane == 5)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (notesManager.LaneNumF[i] == 5)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }

            else if (flickLane == 6)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (notesManager.LaneNumF[i] == 6)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }

            else if (flickLane == 7)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (notesManager.LaneNumF[i] == 7)
                    {
                        manager(i);
                        judge.deleteDataF(i);
                        break;
                    }
                }
            }
        }
    }

    void manager(int i)
    {
        GManager.instance.ratioScore += 5;
        GManager.instance.perfect++;
        GManager.instance.combo++;
        int lane = notesManager.LaneNumF[i];
        message(lane, 0);
    }
        
    void message(int lane,int judge)//判定を表示する
    {
        float x = lane * 0.5f;
        Instantiate(MessageObj[judge], new Vector3(x - 1.75f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
}

