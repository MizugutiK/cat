using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalBool : MonoBehaviour
{
    public bool glTime;               　　 // 時計を止めるフラグを用意します
    public Text goalText;          // goal時に表示する「Goal」をText型として用意します

    private void Start()
    {
        goalText.enabled = false;   //　goalTextのGOALTextを非表示にします
        glTime = false;       //　フラグ変数glTimeをfalseにして、時計を止めない様にします
    }

    private void OnTriggerEnter(Collider other) //　Triggerに触れた時の処理
    {
        if (other.gameObject.tag == "Player")	//　もしあった相手のTagが”Player”なら・・
        {
            glTime = true;          //　フラグの変数glTimeをtrue(真)にします
            goalText.enabled = true;         //　GOALの文字を表示させます

            //カメラ用の文
            GetComponent<BoxCollider>().enabled = false;  　//　開始時にコライダーを消しておきます（条件が揃った時にTrueにします）

            //操作できないようにするための文とか　
         //   GameObject.Find("Player").GetComponent<CPopDir>().jumpPower = 0f; // CPopDirスクリプトのjumpPowerを０にします
        //   GameObject.Find("Player").GetComponent<ThrowingButton>().tag = "Untagged";　　 // PlayerのtagをUntaggedにします
     

        }
    }
}