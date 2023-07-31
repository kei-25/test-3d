using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
/// <Summary>
/// コライダーに衝突したゲームオブジェクトを破棄するスクリプトです。
/// </Summary>
    void Start()
    {

    }

    void Update()
    {

    }

    /// <Summary>
    /// コライダーに衝突したゲームオブジェクトを破棄します。
    /// </Summary>
    void OnCollisionEnter(Collision hit)
    {
        // 衝突した相手を闇の彼方に消し去ります。
        Destroy(hit.gameObject);
    }
}
