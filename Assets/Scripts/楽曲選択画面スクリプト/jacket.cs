using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jacket : MonoBehaviour
{
    [SerializeField] SpawnClones spawnclones;
    [SerializeField] GameObject gameObjectA;

    //public string jacketSongName;
    public Material noneSelectMaterial;
    public List<string> songNameList = new List<string>();

    public int UpDownNum = 0;
    //public List<Material> jacketMaterialList= new List<Material>();
    void Start()
    {
        noneSelectMaterial = Resources.Load<Material>("Materials/Materials/jojo");
        Debug.Log(spawnclones.inputJson.selectList.Length);
    }

    bool flag = true;
    
    void Update()
    {
        if (flag)//一番最初のジャケット画像を貼り付ける
        {
            flag = false;
            chengeMaterial(0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (UpDownNum != spawnclones.inputJson.selectList.Length)
            {
                UpDownNum++;
                Debug.Log(UpDownNum);
                if (UpDownNum == spawnclones.SelectObjs.Count)
                {
                    UpDownNum = 0;
                    chengeMaterial(UpDownNum);
                }
                else
                {
                    chengeMaterial(UpDownNum);
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (UpDownNum != -1)
            {
                UpDownNum--;

                if (UpDownNum == -1)
                {
                    UpDownNum = spawnclones.SelectObjs.Count - 1;
                    Debug.Log(UpDownNum);
                    chengeMaterial(UpDownNum);
                }
                else
                {
                    chengeMaterial(UpDownNum);
                }
            }
        }

    }

    void chengeMaterial(int i)
    {
        // マテリアルを変更したいゲームオブジェクトのRendererコンポーネントを取得
        //Renderer renderer = targetObject.GetComponent<Renderer>();
        if (spawnclones.jacketMaterialList[i] != null)
        {
            Renderer renderer = gameObjectA.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = spawnclones.jacketMaterialList[i];
            }
        }
        else
        {
            Renderer renderer = gameObjectA.GetComponent<Renderer>();
            renderer.material = noneSelectMaterial;
        }
    }
}
