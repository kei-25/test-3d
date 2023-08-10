using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class difficultyColour : MonoBehaviour
{
    [SerializeField] SpawnClones spawnclones;
    [SerializeField] GameObject gameObjectA;
    [SerializeField] GameObject gameObjectDifficulty1;
    [SerializeField] GameObject gameObjectDifficulty2;

    public List<Material> backMaterialList = new List<Material>();
    public Material selectMaterial;

    public static int sideNumS = 0;
    List<string> difficultyTextList = new List<string>() { "    EASY  →", "←  HARD  →", "← EXPERT →", "← MASTER  ." };

    void Start()
    {
        //sideNumS = 0;
        for (int i=0; i<4;i++)
        {
            string soezi = i.ToString();
            string pathName = "Materials/difficulty/M" + soezi;
            backMaterialList.Add(Resources.Load<Material>(pathName));
        }
        chengeMaterial(sideNumS);
        spawnclones.chengeLv(sideNumS);
    }
    
    bool flag = true;
    void Update()
    {
        if (flag)
        {
            flag = false;
            spawnclones.chengeLv(sideNumS);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (sideNumS != 0)
            {
                sideNumS--;
                chengeMaterial(sideNumS);
                spawnclones.chengeLv(sideNumS);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (sideNumS != 3)
            {
                sideNumS++;
                chengeMaterial(sideNumS);
                spawnclones.chengeLv(sideNumS);
            }
        }
    }
    void chengeMaterial(int i)
    {
        // マテリアルを変更したいゲームオブジェクトのRendererコンポーネントを取得
        //Renderer renderer = targetObject.GetComponent<Renderer>();
        if (backMaterialList[i] != null)
        {
            Renderer renderer1 = gameObjectA.GetComponent<Renderer>();
            Renderer renderer2 = gameObjectDifficulty1.GetComponent<Renderer>();
            Renderer renderer3 = gameObjectDifficulty2.GetComponent<Renderer>();
            Transform TextTransform = gameObjectDifficulty1.transform.Find("難易度表示Text");
            if (renderer1 != null)
            {
                renderer1.material = backMaterialList[i];
                renderer2.material = backMaterialList[i];
                renderer3.material = backMaterialList[i];
            }
            TextMeshPro textMeshProLv = TextTransform.GetComponent<TextMeshPro>();
            if (textMeshProLv != null)
            {
                textMeshProLv.text = difficultyTextList[i];
            }
        }
    }
    public static int GetDifficultyNum()
    {
        return sideNumS;
    }
}
