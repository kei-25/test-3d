using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
/// <Summary>
/// �R���C�_�[�ɏՓ˂����Q�[���I�u�W�F�N�g��j������X�N���v�g�ł��B
/// </Summary>
    void Start()
    {

    }

    void Update()
    {

    }

    /// <Summary>
    /// �R���C�_�[�ɏՓ˂����Q�[���I�u�W�F�N�g��j�����܂��B
    /// </Summary>
    void OnCollisionEnter(Collision other)
    {
        // �Փ˂���������ł̔ޕ��ɏ�������܂��B
        Destroy(other.gameObject);
    }
}
