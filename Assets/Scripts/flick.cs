using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        // �J�[�\���ʒu��z���W��10��
        mousePosition.z = 10;
        // �J�[�\���ʒu�����[���h���W�ɕϊ�
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x , 97f, 2.8f)); //��220,�E880
        // GameObject��transform.position�ɃJ�[�\���ʒu(���[���h���W)����
        if (mousePosition.x > 237 && mousePosition.x < 865)
        {
            transform.position = target;
        }
    }
}
