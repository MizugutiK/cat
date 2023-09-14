using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPop : MonoBehaviour
{
    public float jumpPower = 5.0f;    // ジャンプ力を用意します、inspectorからも調整できるようpublic変数にします
    Rigidbody rigidBody;                     // rigidbody型の変数rigidBodyを用意します
    GameObject cursorManager;　　　 // GameObject型の変数cursorManagerを用意します

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();      // 変数rigidbodyにrigidbodyコンポネントを入れます
        cursorManager = GameObject.Find("CursorManager");	　 // 変数cursorManagerに”CursorManager”という名前のObjectを探して入れます

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))       //　もしMouseボタンが1回（MouseBottonDown）押されたら
        {
            rigidBody.velocity = Vector3.zero;                                                                              // 落下速度を一度リセットします　(0f,0f,0f)をいれます
            rigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);                     // 上（y軸）方向に衝撃力を加えます
            cursorManager.GetComponent<CursorPop>().ClickVisible();　　 // 変数cursorManager内のCursorPopスクリプト内のClickVisible関数を呼びます

        }
    }

}
