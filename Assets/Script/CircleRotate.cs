using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour
{
    private Rigidbody rigid;                  //Rigidbody型の変数　rigidを用意します
    public float speed = 2.0f;              // 回転スピード
    public float rad = 4.0f;                   //半径の大きさを変数radに入れます
    private float centerPos;                //回転中心の位置
    private float xPos;                            //xのポジション


    void Start()
    {
        centerPos = this.gameObject.transform.position.y;   	 //  このオブジェクトのｙ座標を回転の中心にします
        xPos = this.gameObject.transform.position.x;		//　このオブジェクトのｘ座標を変数ｘPosに取ります　	
        rigid = gameObject.AddComponent<Rigidbody>();    //　このオブジェクトにRigidbodyコンポネントを加えて、変数rigidに入れます
        rigid.isKinematic = true;			 //　rigidのIsKinematic フラグをtrueにします
    }


    void FixedUpdate()
    {
        //　rigidbodyのMovePosition関数を使い、ｘPosにsin関数で増減する値を足し、ｙPos に中心位置にcos関数で増減する値を入れます
        rigid.MovePosition(new Vector3(xPos + rad * Mathf.Sin(Time.time * speed), centerPos + rad * Mathf.Cos(Time.time * speed), 0f));
    }

}
