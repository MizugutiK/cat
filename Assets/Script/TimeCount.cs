using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;　　　	　//　UIのモジュールを継承（読み込んで）しておきます

public class TimeCount : MonoBehaviour
{
    public Text timeText;     // 時間のTextオブジェクトを格納する変数timeTextを用意します
    float timeCount;              //浮動小数点型の変数　timeCountを用意します
    public bool stopTime;                //時計を止めるフラグを用意します
    public bool startTime;                //時計を始めるフラグを用意します


    private void Start()
    {
        startTime = false;  //startTimeフラグはfalseにして始めます
    }


    void Update()
    {
        if (startTime == true)　　　　　　//　startTimeフラグがtrueなら（StartBoolオブジェクトに触れたなら）・・
    　   {
            //bool変数stopTimeに、同じオブジェクト内のGoalBoolスクリプトのbool変数glTime を入れます
            stopTime = GetComponent<GoalBool>().glTime;

            if (stopTime == false)  //　もし変数stopTimeの値が「false」ならば
            {
                timeCount += Time.deltaTime;                      //変数timeCountに毎フレーム間の時間を足していきます
                timeText.text = "Time:" + timeCount.ToString("f2"); //その時間の値をTextで下2桁（f2）まで表示します

            }
            return;
        }

    }
}
