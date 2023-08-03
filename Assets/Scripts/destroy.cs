using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision hit)
    {
        checkItem(hit.collider.gameObject);
    }

    void checkItem(GameObject obj)
    {
        if (obj.name == "ロングノーツ(Clone)")
        {
            Destroy(notesManager.NotesObjL[0]);
        }
    }
}
