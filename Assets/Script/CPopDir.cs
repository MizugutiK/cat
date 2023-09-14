using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPopDir : MonoBehaviour
{
    public float jumpPower = 5.0f;    // ジャンプ力を用意します、inspectorからも調整できるようpublic変数にします
    Rigidbody rigidBody;                   　// rigidbody型の変数rigidBodyを用意します
    GameObject cursorManager;   // GameObject型の変数cursorManagerを用意します

    //scoreに関する文
    ScoreCount scoreCount;	//　 ScoreCountクラス型の変数scoreCountを用意します
    public int point = 1;		 //　 一回に加算されるpointを１にします


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();           // 変数rigidbodyにrigidbodyコンポネントを入れます
　　　// 変数cursorManagerにCursorManagerという名前のObjectを探してきて入れます　　
        cursorManager = GameObject.Find("CursorManager");

        //scoreに関する文
        scoreCount = gameObject.GetComponent<ScoreCount>();  // このオブジェクトにあるScoreCoountクラスを変数scoreCountに入れます

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //　もしMouseボタンが1回（MouseBottonDown）押されたら
        {
            //　Vector2型の変数fDirに、cursorManager 変数内のCursorPopスクリプトのforceDir変数を呼びます
            Vector2 fDir = cursorManager.GetComponent<CursorPop>().forceDir;
            rigidBody.velocity = Vector3.zero;  // 落下速度を一度０を入れて、現在の速度をリセットします
　　　　 // 方向ベクトルfDir.xとfDir.y方向にjumpPowerの値をかけた分の衝撃力を加えます
            rigidBody.AddForce(new Vector2(fDir.x * jumpPower, fDir.y * jumpPower), ForceMode.Impulse);
            //　cursorManagerオブジェクトのCursorPopスクリプトのClickVisibleメソッドを呼びます（カーソルの表示）
            cursorManager.GetComponent<CursorPop>().ClickVisible();


            //scoreCount.AddPoint(point);
            //　scoreCount変数に読み込んだAddPointメソッドを呼んで、変数pointの数字をいれます

        }
    }

}
