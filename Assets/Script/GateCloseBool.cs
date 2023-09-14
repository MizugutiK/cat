using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCloseBool : MonoBehaviour
{
    public GameObject obj;				//　閉めたいゲートオブジェクトを入れる変数を用意します

    void OnTriggerEnter(Collider other)			//　もし何かがこのトリガーに触れたら・・
    {
        if (other.tag == "Player")				 //　そのオブジェクトのTagが「Player」ならば・・
        {
            //　変数objに入れられたオブジェクトに入ってるGateMoveスクリプト内の変数closeBoolをtrueにします
            obj.GetComponent<GateMove>().closeBool = true;
        }
    }

}
