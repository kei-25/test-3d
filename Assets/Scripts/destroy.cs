using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    [SerializeField] NotesManager notesManager;//�X�N���v�g�unotesManager�v������ϐ�
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
        if (obj.name == "�����O�m�[�c(Clone)")
        {
            Destroy(notesManager.NotesObjL[0]);
        }
    }
}
