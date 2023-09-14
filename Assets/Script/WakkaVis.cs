using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakkaVis : MonoBehaviour
{
    public GameObject cursorMaker;             //攻撃時に現れるカーソルの絵を入れる変数
    private Vector3 targetPos;                    // transform型の変数targetPosを用意します 

    public void ClickVisible()		 //呼び出せるようにpublicにしたClickVisible()メソッド
    {　　//Player-01からtargetPos変数を取ってきます
        targetPos = GameObject.Find("Player-01").GetComponent<ThrowingButton>().targetPos;
        cursorMaker.transform.position = new Vector3(targetPos.x, -1.4f, targetPos.z);　 //マーカーの位置をtargetPosの位置にします
　       cursorMaker.SetActive(true);            //マーカーの絵を表示します

        StartCoroutine("ClickInvisible");　　		 //　コルーチンでClickInvisibleメソッドに飛びます
    }

    IEnumerator ClickInvisible()　　　　 //　コルーチンで飛んでくる、マーカーを非表示にするためのClickInvisibleメソッドです
    {
        yield return new WaitForSeconds(3.5f);　 	//　3.5秒間待ちます
        cursorMaker.SetActive(false); 		//　マーカーの絵を非表示にします
    }

}
