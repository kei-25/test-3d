using System;
using UnityEngine;
using TMPro;//new!!
//using System.Diagnostics;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{
    //�ϐ��̐錾
    [SerializeField] private GameObject[] MessageObj;//�v���C���[�ɔ����`����Q�[���I�u�W�F�N�g
    [SerializeField] NotesManager notesManager;//�X�N���v�g�unotesManager�v������ϐ�

    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI maxcomboText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI perfectText;
    [SerializeField] private TextMeshProUGUI greatText;
    [SerializeField] private TextMeshProUGUI goodText;
    [SerializeField] private TextMeshProUGUI missText;



    AudioSource audio;
    [SerializeField] AudioClip hitSound;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        maxcomboText.text = "0";
        perfectText.text = "0";
        greatText.text = "0";
        goodText.text = "0";
        missText.text = "0";
    }
    int tempCombmax = 0;
    int tempcomb;
    bool longNoteflag0 = false;
    bool longNoteflag1 = false;
    bool longNoteflag2 = false;
    bool longNoteflag3 = false;
    void Update()
    {
        if (GManager.instance.Start)
        {

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


            if (Input.GetKeyDown(KeyCode.D))//�Z�L�[�������ꂽ�Ƃ�
            {
                longNoteflag0 =  true;
                if (notesManager.LaneNum[0] == 0)//�����ꂽ�{�^���̓��[���̔ԍ��Ƃ����Ă��邩�H
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
                longNoteflag1 = true;
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
                longNoteflag2 = true;
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
                longNoteflag3 = true;
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


            if (longNoteflag0)
            {
                for (int i = 0; i < notesManager.NotesTimeL.Count; i++)
                {
                    if (Time.time > notesManager.NotesTimeL[i] + 0.0f + GManager.instance.StartTime && notesManager.LaneNumL[i] == 0)
                    {
                        GManager.instance.ratioScore += 5;
                        GManager.instance.perfect++;
                        GManager.instance.combo++;
                        messageL(0);
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
                        messageL(0);
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
                        messageL(0);
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
                        messageL(0);
                        deleteDataL(i);
                        Debug.Log("Perfect");
                        break;
                    }
                }
            }


            //float p = notesManager.NotesTimeL[0] + 0.1f + GManager.instance.StartTime;
            //Debug.Log(longNoteflag0+"A"+longNoteflag1 + "A" + longNoteflag2 + "A" + longNoteflag3);
            if (Time.time > notesManager.NotesTimeL[0] + 0.1f + GManager.instance.StartTime)
            {
                messageL(3);
                deleteDataL(0);
                Debug.Log("Miss");
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                //GManager.instance.ratioScore += 5;
                //�~�X
            }

            if (Time.time > notesManager.NotesTime[0] + 0.1f + GManager.instance.StartTime)//�{���m�[�c���������ׂ����Ԃ���0.1�b�����Ă����͂��Ȃ������ꍇ
            {
                message(3);
                deleteData(0);
                Debug.Log("Miss");
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                //GManager.instance.ratioScore += 5;
                //�~�X
            }
        }

    }
    


    void Judgement(float timeLag, int numOffset)
    {
        audio.PlayOneShot(hitSound);
        if (timeLag <= 0.06)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.06�b�ȉ���������
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
            if (timeLag <= 0.09)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.9�b�ȉ���������
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
                if (timeLag <= 0.11)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.11�b�ȉ���������
                {
                    Debug.Log("Bad");
                    message(2);
                    GManager.instance.ratioScore += 1;//new!!
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
    float GetABS(float num)//�����̐�Βl��Ԃ��֐�
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

    void deleteData(int numOffset)//���łɂ��������m�[�c���폜����֐�
    {
        //NotesManager notesManager = this.notesManager; // notesManager�ϐ����g����NotesManager�̃C���X�^���X���擾
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        notesManager.NoteNum.RemoveAt(numOffset);
        //notesManager.NotesObj.RemoveAt(numOffset);
        //GameObject firstGameObject = notesManager.NotesObj[numOffset];
        Destroy(notesManager.NotesObj[numOffset]);          // �I�u�W�F�N�g���V�[������폜
        notesManager.NotesObj.Remove(notesManager.NotesObj[numOffset]);  // ���X�g����I�u�W�F�N�g���폜
        
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

    public void deleteDataF(int numOffset)//���łɂ��������m�[�c���폜����֐�
    {
        //NotesManager notesManager = this.notesManager; // notesManager�ϐ����g����NotesManager�̃C���X�^���X���擾
        notesManager.NotesTimeF.RemoveAt(numOffset);
        notesManager.LaneNumF.RemoveAt(numOffset);
        notesManager.NoteTypeF.RemoveAt(numOffset);
        notesManager.NoteNumF.RemoveAt(numOffset);
        Destroy(notesManager.NotesObjF[numOffset]);          // �I�u�W�F�N�g���V�[������폜
        notesManager.NotesObjF.Remove(notesManager.NotesObjF[numOffset]);  // ���X�g����I�u�W�F�N�g���폜

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
        //NotesManager notesManager = this.notesManager; // notesManager�ϐ����g����NotesManager�̃C���X�^���X���擾
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


    void message(int judge)//�����\������
    {
        Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
    void messageL(int judge)//�����\������
    {
        Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNumL[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }

}
