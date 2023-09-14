using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;　　　	　//　UIのモジュールを継承（読み込んで）しておきます

public class StartBool : MonoBehaviour
{
    public Text startText;       // start時に表示する「START」をText型として用意します

    void Start()
    {
        startText.enabled = true;　　//startTextに入れてある「START」を表示します
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")　　　　　　　　//　もし当たったオブジェクトのtagがPlayerなら・・
        {
            //　GoalTriggerという名前のオブジェクトに入ってるTimeCountスクリプトのstratTime フラグをtrueにします
            GameObject.Find("GoalTrigger").GetComponent<TimeCount>().startTime = true;
            startText.enabled = false;　　　　　　　　　　　　//startText 変数に入れられたTextを非表示にします
        }
    }

}
