using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class SpawnClones : MonoBehaviour
{
    [SerializeField] GameObject gameObjectA;
    [SerializeField] GameObject gameObjectBack;
    [SerializeField] GameObject gameObjectDifficultyText;
    [SerializeField] GameObject gameObjectJacket;
    [SerializeField] GameObject gameObjecttransition;
    [SerializeField] GameObject gameObjectB;
    [SerializeField] GameObject gameObjectSetting;
    public Data inputJson;
    public List<GameObject> SelectObjs = new List<GameObject>();
    public List<GameObject> tempSelectObjs = new List<GameObject>();

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

    public static int UpDownNumS = 0;

    public string jacketSongName;
    public List<Material> jacketMaterialList = new List<Material>();

    public Material selectMaterial;
    public Material notSelectMaterial;
    string songselect = "seetMusicSelect";

    //public Renderer[] renderers; // 透明にするオブジェクトのRendererコンポーネントの配列
    public List<Renderer> renderers = new List<Renderer>();
    void Start()
    {
        UpDownNumS = 0;
        LoadJson(songselect);
        selectMaterial = Resources.Load<Material>("Materials/NameBack/songNameBack");
        notSelectMaterial = Resources.Load<Material>("Materials/NameBack/songNameBack1");
        materialChange(0);

        for (int i = 0; i < inputJson.selectList.Length; i++)
        {
            jacketSongName = "Materials/Materials/" + inputJson.selectList[i].songName;
            jacketMaterialList.Add(Resources.Load<Material>(jacketSongName));
        }
        /*
            Renderer tempRender = gameObjecttransition.GetComponent<Renderer>();
            renderers.Add(tempRender);*/
        
    }
    private void LoadJson(string songselect)
    {
        // ResourcesフォルダからJSONファイルを読み込む
        TextAsset textAsset = Resources.Load<TextAsset>(songselect);
        if (textAsset != null)
        {
            // JSONデータをパースしてDataオブジェクトに変換
            inputJson = JsonUtility.FromJson<Data>(textAsset.ToString());
        }
        else
        {
            Debug.LogError("Failed to load JSON file: " + songselect);
        }


        for (int i = 0; i < inputJson.selectList.Length; i++)
        {
            GameObject newClone = Instantiate(gameObjectA, new Vector3(2.56f, i * 1.4f, -4.0001f), Quaternion.identity);
            newClone.name = i.ToString();
            SelectObjs.Add(newClone);

            // 'TextUpDaterLv'という名前のGameObjectの中のTextMeshPro-Textを変更
            Transform lvTextTransform = newClone.transform.Find("lvText");
            if (lvTextTransform != null)
            {
                TextMeshPro textMeshProLv = lvTextTransform.GetComponent<TextMeshPro>();
                if (textMeshProLv != null)
                {
                    textMeshProLv.text = "Lv." + inputJson.selectList[i].difficultyEasy;
                }
            }
            else
            {
                Debug.LogError("GameObject with name 'TextUpDaterLv' not found in the child objects.");
            }

            Transform lvText = newClone.transform.Find("lvText");
            if (lvText != null)
            {
                lvText.name = "lvText" + i.ToString();
            }

            // 'TextUpDater'という名前のGameObjectの中のTextMeshPro-Textを変更
            Transform songNameTextTransform = newClone.transform.Find("songNameText");
            if (songNameTextTransform != null)
            {
                TextMeshPro textMeshPro = songNameTextTransform.GetComponent<TextMeshPro>();
                if (textMeshPro != null)
                {
                    songNameTextTransform.name = "songNameText" + i.ToString();
                    textMeshPro.text = inputJson.selectList[i].songName;
                }
            }
            else
            {
                Debug.LogError("GameObject with name 'TextUpDater' not found in the child objects.");
            }
        }
    }

    public int UpDownNum = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (UpDownNum != inputJson.selectList.Length)
            {
                UpDownNum++;
                if(UpDownNum == SelectObjs.Count)
                {
                    moveObject(2);
                    UpDownNum = 0;
                    UpDownNumS = UpDownNum;
                }
                else
                {
                    moveObject(0);
                    UpDownNumS = UpDownNum;
                }
                materialChange(UpDownNum);

            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (UpDownNum != -1)
            {
                UpDownNum--;
                if(UpDownNum == -1)
                {
                    moveObject(3);
                    UpDownNum = SelectObjs.Count-1;
                    UpDownNumS = UpDownNum;
                }
                else
                {
                    moveObject(1);
                    UpDownNumS = UpDownNum;
                }
                materialChange(UpDownNum);
            }

        }/*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
        }*/
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Return");
            tempSelectObjs = SelectObjs;
            tempSelectObjs.Add(gameObjectBack);
            tempSelectObjs.Add(gameObjectDifficultyText);
            tempSelectObjs.Add(gameObjectB);
            tempSelectObjs.Add(gameObjectSetting);
            StartCoroutine(MoveObjectsAndLoadScene(tempSelectObjs.ToArray()));
        }
            
    }
    public Transform targetTransform;
    public float duration = 1f;
    public float targetX = 12f;

    IEnumerator MoveObjectsAndLoadScene(GameObject[] objectsToMove)
    {
        List<Coroutine> moveCoroutines = new List<Coroutine>();

        foreach (GameObject obj in objectsToMove)
        {
            Coroutine moveCoroutine = StartCoroutine(MoveObject(obj.transform, targetX, duration));
            moveCoroutines.Add(moveCoroutine);
        }

        foreach (Coroutine coroutine in moveCoroutines)
        {
            yield return coroutine; // 全てのオブジェクトの移動が終わるまで待機
        }
        Transform jacketTransform = gameObjectJacket.transform;
        StartCoroutine(MoveSpecificObject(jacketTransform, new Vector3(0f, 0f, jacketTransform.position.z), duration));

    }

    IEnumerator MoveObject(Transform objTransform, float targetX, float duration)
    {
        float elapsedTime = 0f;
        float startingX = objTransform.position.x;
        Vector3 targetPosition = new Vector3(targetX, objTransform.position.y, objTransform.position.z);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float newX = Mathf.Lerp(startingX, targetX, t*t);
            objTransform.position = new Vector3(newX, objTransform.position.y, objTransform.position.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objTransform.position = targetPosition;
    }

    IEnumerator MoveSpecificObject(Transform objTransform, Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = objTransform.position;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            objTransform.position = Vector3.Lerp(startingPosition, targetPosition, t * t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objTransform.position = targetPosition;
        Thread.Sleep(1800);
        SceneManager.LoadScene("MainScene");
    }

    string targetObjectName;
    public void chengeLv(int i)
    {
        for (int j = 0; j < SelectObjs.Count; j++)
        {
            GameObject newClone = SelectObjs[j];
            targetObjectName = "lvText" + j.ToString();

            Transform lvTextTransform = newClone.transform.Find(targetObjectName);
            if (lvTextTransform != null)
            {
                TextMeshPro textMeshProLv = lvTextTransform.GetComponent<TextMeshPro>();
                if (textMeshProLv != null)
                {
                    if (i == 0)
                    {
                        textMeshProLv.text = "Lv." + inputJson.selectList[j].difficultyEasy;
                    }
                    else if (i == 1)
                    {
                        textMeshProLv.text = "Lv." + inputJson.selectList[j].difficultyHard;
                    }
                    else if (i == 2)
                    {
                        textMeshProLv.text = "Lv." + inputJson.selectList[j].difficultyExpert;
                    }
                    else if (i == 3)
                    {
                        textMeshProLv.text = "Lv." + inputJson.selectList[j].difficultyMaster;
                    }
                }
            }
        }

    }


    GameObject targetObject;
    private void materialChange(int targetObjectNameNum)
    {

        for (int i = 0; i < inputJson.selectList.Length; i++)
        {
            targetObjectName = i.ToString();
            targetObject = GameObject.Find(targetObjectName);

            // オブジェクトが見つかった場合にはマテリアルを変更します。
            if (targetObject != null)
            {
                Renderer renderer = targetObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = notSelectMaterial;
                }
            }
        }
        targetObjectName = targetObjectNameNum.ToString();
        targetObject = GameObject.Find(targetObjectName);


        if (targetObject != null)
        {
            Renderer renderer = targetObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = selectMaterial;
            }
        }

    }

    void moveObject(int j)
    {
        if (j == 1)
        {
            for (int i = 0; i < SelectObjs.Count; i++)
            {
                Transform myTransform = SelectObjs[i].transform;
                Vector3 Pos = myTransform.localPosition;
                Pos.y += 1.4f;
                myTransform.position = Pos;
            }
        }
        else if (j == 0)
        {
            for (int i = 0; i < SelectObjs.Count; i++)
            {
                Transform myTransform = SelectObjs[i].transform;
                Vector3 Pos = myTransform.localPosition;
                Pos.y -= 1.4f;
                myTransform.position = Pos;
            }
        }
        else if (j == 2)
        {
            for (int i = 0; i < SelectObjs.Count; i++)
            {
                Transform myTransform = SelectObjs[i].transform;
                Vector3 Pos = myTransform.localPosition;
                Pos.y = 1.4f*i;
                myTransform.position = Pos;
            }
        }
        else if (j == 3)
        {
            for (int i = 0; i < SelectObjs.Count; i++)
            {
                int tempNum = SelectObjs.Count - (i+1);
                Transform myTransform = SelectObjs[tempNum].transform;
                Vector3 Pos = myTransform.localPosition;
                Pos.y = 1.4f * -i;
                myTransform.position = Pos;
            }
        }
    }


   
    public float fadeDuration = 0.5f; // フェードの時間（秒）

    private bool isFading = false;
    
    public void StartFadeOut()
    {
        if (!isFading)
        {
            isFading = true;
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color originalColor;

        // 初期カラーを保存
        Color[] originalColors = new Color[renderers.Count];
        for (int i = 0; i < renderers.Count; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // 透明度を更新
            for (int i = 0; i < renderers.Count; i++)
            {
                originalColor = originalColors[i];
                Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
                renderers[i].material.color = Color.Lerp(originalColor, targetColor, elapsedTime / fadeDuration);
            }

            yield return null;
        }

        // 最終的に完全に透明にする
        for (int i = 0; i < renderers.Count; i++)
        {
            originalColor = originalColors[i];
            Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
            renderers[i].material.color = targetColor;
        }

        isFading = false;
    }


    void ChangeScene()
    {
        Thread.Sleep(1800);
        SceneManager.LoadScene("MainScene");
    }
    public static int GetSelectSong()
    {
        return UpDownNumS;
    }

}