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
        // カーソル位置のz座標を10に
        mousePosition.z = 10;
        // カーソル位置をワールド座標に変換
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x , 97f, 2.8f)); //左220,右880
        // GameObjectのtransform.positionにカーソル位置(ワールド座標)を代入
        if (mousePosition.x > 237 && mousePosition.x < 865)
        {
            transform.position = target;
        }
    }
}
