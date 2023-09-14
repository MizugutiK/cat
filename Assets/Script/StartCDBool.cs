using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCDBool : MonoBehaviour
{
    public GameObject startText;       // start時に表示する「START」をGameObject型として用意します

    void Start()
    {
        startText.SetActive(true);　　//startTextに入れてある「START」を表示します
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")　　//　もし当たったオブジェクトのtagがPlayerなら・・
        {　　　//　GoalTriggerという名前のオブジェクトに入ってるTimeCountスクリプトのstratTime フラグをtrueにします
            GameObject.Find("GoalTrigger").GetComponent<CountDown>().startTime = true;
            startText.SetActive(false);　　//startText 変数に入れられたTextを非表示にします
        }
    }

}
