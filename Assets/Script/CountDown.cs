using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text timeText;                        　　   //     カウントダウンのTextを格納する変数timeTextを用意
    public float countDown = 15.00f;     　 　 //　制限時間を入れる浮動小数点型の変数countDownを用意します
    public bool startTime;                      　 　  //　 カウントダウンを始めるフラグを用意します
    private bool stopTime;                      　　  //     カウントダウンを止めるフラグを用意します
    public Text gameOver;       　　                 // 　GameOverの表示文字オブジェクトを入れる変数gameOver
    public GameObject player;                　    //　 playerキャラを入れる変数playerを用意します
    public Material die;  		   //      Material型の変数dieを用意します
    public ParticleSystem smoke;       //      CountDownが間に合わなかった時に出す煙（パーティクル）の変数


    void Start()
    {
        startTime = false;　　			//startTimeフラグはfalseで始めます
        timeText.text = "Time:" + countDown.ToString("f2"); 	//その時間の値をTextで下2桁（f2）まで表示します
        gameOver.enabled = false;           //gameOver文字を非表示にします 

    }
    void Update()
    {
        if (startTime == true)      				//　startTimeフラグがtrueなら・・
        {
            stopTime = GetComponent<GoalBool>().glTime;  		// GoalBoolスクリプトのglTimeフラグを呼びます
            if (stopTime == false)　　　　　　　　　　　		//  もしstopTimeがfalse（ゴールしてない）なら　　
            {
                countDown -= Time.deltaTime;               		 //変数countDownから毎フレーム間の時間を引いていきます
                timeText.text = "Time:" + countDown.ToString("f2");     //その時間の値をTextで下2桁（f2）まで表示します


                if (countDown <= 0.01)　				//もしcountDownの値が0.01以下になったら・・
                {
                    timeText.text = "Time:" + "0.00";           //時間表示に0.00を表示させます
                                                                //PlayerオブジェクトのCPopDirスクリプトのjumpPowerメソッドのjumpPowerの値を0ｆにします
                    GameObject.Find("Player").GetComponent<CPopDir>().jumpPower = 0f;
                    startTime = false;              //　変数startTimeをfalseにしてupdate()に入らないようにします
                    GameOver();				//ＧａｍｅＯｖｅｒメソッドに飛びます	
                }
            }
        }
        return;   //　戻ります
    }
    public void GameOver()      //GameOverメソッドです
    {
        gameOver.enabled = true;			　 	//　GAMEOVERのtextを表示します
        GameObject playerOb = GameObject.Find("Player");		 //　playerという名のオブジェクトを探します
        playerOb.GetComponent<Renderer>().material.color = die.color;  //　そのRendererのmaterialのcolorをdieのものにします

        //　smokeオブジェクトの位置にplayerオブジェクトの位置を入れます
        smoke.transform.position = playerOb.GetComponent<Transform>().position;
        smoke.Play();　　 					//　smokeをプレイさせます
        player.tag = "Untagged";        //　playerのtagを”Untaggedにします（Goalに触れてもgoal表示させないため）

    }
}


