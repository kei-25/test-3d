using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    // JSON�f�[�^���i�[����N���X�̒�`
    [System.Serializable]
    public class Data
    {
        public songSelect[] selectList;
    }

    // �ȏ����i�[����N���X�̒�`
    [System.Serializable]
    public class songSelect
    {
        public string songName;
        public int difficultyEasy;
        public int difficultyHard;
        public int difficultyExpert;
        public int difficultyMaster;
    }

    void Start()
    {
        string songselect = "seetMusicSelect";
        LoadJson(songselect);
    }

    private void LoadJson(string songselect)
    {
        // Resources�t�H���_����JSON�t�@�C����ǂݍ���
        TextAsset textAsset = Resources.Load<TextAsset>(songselect);
        if (textAsset != null)
        {
            // JSON�f�[�^���p�[�X����Data�I�u�W�F�N�g�ɕϊ�
            Data inputJson = JsonUtility.FromJson<Data>(textAsset.ToString());

            // selectList�̊e�v�f���R���\�[���ɏo��
            /*foreach (songSelect song in inputJson.selectList)
            {
                Debug.Log("Song Name: " + song.songName);
                Debug.Log("Difficulty Easy: " + song.difficultyEasy);
                Debug.Log("Difficulty Hard: " + song.difficultyHard);
                Debug.Log("Difficulty Expert: " + song.difficultyExpert);
                Debug.Log("Difficulty Master: " + song.difficultyMaster);
                Debug.Log("------------------------");
            }*/
            for(int i=0; i<inputJson.selectList.Length;i++)
            {
                Debug.Log("Song Name: " + inputJson.selectList[i].songName);
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file: " + songselect);
        }
    }
}
