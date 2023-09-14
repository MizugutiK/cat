using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMove : MonoBehaviour
{
    public bool gateBool;　　　　　　　	//　Gateを動かすフラグのgateBoolを用意します　
    public float maxHeight = 10.0f;       //　ゲートを動かす最大の高さを決めておきます

    //ゲートをもとに戻すよう
    private Vector3 oriPos;         // 元の位置を格納しておく変数を用意します 
    public bool closeBool;          // ゲートを閉めるフラグを用意します　

    void Start()
    {
        gateBool = false;            //　Gateフラグをfalseにしておきます

  　　//ゲートをもとに戻すよう
        oriPos = gameObject.transform.position;     　　//はじまりのゲートポジションを取得しておきます　
        closeBool = false;                                                      //ゲートを閉めるフラグをfalseにしておきます

    }


    void Update()
    {
        if (gateBool == true) 		 	//　もし、gateBoolフラグがtrueならば・・
        {
            maxHeight -= 0.1f;		 	//　ゲートの最大移動高さから0.1づつ減らしていきます
            this.transform.position += new Vector3(0f, 0.1f, 0f);　 //　このオブジェクトのｙポジションを0.1づつ足していきます
            if (maxHeight <= 0.0f)			 //　もし最大移動高さの値が0になったら・・
            {
                gateBool = false;			 //　ｇateBoolフラグをfalseにして、移動を止めます
            }
        }
        //ゲートをもとに戻すよう
        if (gateBool == false & closeBool == true)                          //もしgateBoolがfalseでcloseBoolがtrueの時には
        {
            this.transform.position -= new Vector3(0f, 0.1f, 0f);　//このオブジェクトのｙの値から0.1づつ引いて行きます
            if (transform.position.y - oriPos.y <= 0.1f)                      //もし始めの位置oriPosとの差が0.1以下になったら・・
            {
                closeBool = false;                                                           //closeBoolフラグをfalseに戻します
            }
        }

    }
}
