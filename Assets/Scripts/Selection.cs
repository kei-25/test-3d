using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    // JSONデータを格納するクラスの定義
    [System.Serializable]
    public class Data
    {
        public songSelect[] selectList;
    }

    // 曲情報を格納するクラスの定義
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
        // ResourcesフォルダからJSONファイルを読み込む
        TextAsset textAsset = Resources.Load<TextAsset>(songselect);
        if (textAsset != null)
        {
            // JSONデータをパースしてDataオブジェクトに変換
            Data inputJson = JsonUtility.FromJson<Data>(textAsset.ToString());

            // selectListの各要素をコンソールに出力
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
