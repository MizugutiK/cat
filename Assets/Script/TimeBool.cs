using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBool : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)　 //　トリガーに当たった場合
    {
        if (other.gameObject.tag == "Player")　　　 //　もし当たったオブジェクトのTagが”Player”なら
        {
            //　GoalTriggerと言う名前のオブジェクトを見つけて、そこにあるstartTimeをfalseにします
            //GameObject.Find("GoalTrigger").GetComponent<CountDown>().startTime = false;
            //　GoalTriggerと言う名前のオブジェクトを見つけて、そこにあるcountDownに15を足します            　
            //GameObject.Find("GoalTrigger").GetComponent<CountDown>().countDown += 15.00f;
        }
    }
}
