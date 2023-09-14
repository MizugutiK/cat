using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCount : MonoBehaviour
{
    ScoreCount scoreCount;		//　ScoreCount型の変数　scoreCountをつくります
    public int point = 1;        //　足されるポイントの値を入れる変数pointを用意します

    //ゲート動作用兼アイテムカウント用
    private GameObject[] itemObj;                //  scene内にあるアイテムtagを持つオブジェクトを[ ]に格納する
    private int itemNum;                                  //  アイテムtagを持つオブジェクトの数を格納する変数

 //ゲート動作用兼アイテムカウント用2
    private GameObject[] itemLv2Obj;            //  scene内にあるアイテムLv2tagを持つオブジェクトを「」に格納する
    private int itemLv2Num;                             //  アイテムLv2tagを持つオブジェクトの数を格納する変数

    //ゲート動作用兼アイテムカウント用2
    private GameObject[] itemLv3Obj;            //  scene内にあるアイテムLv2tagを持つオブジェクトを「」に格納する
    private int itemLv3Num;                             //  アイテムLv2tagを持つオブジェクトの数を格納する変数

    public AudioSource audioSource;	//　音を鳴らすシステムAudioSourceを用意します
    public AudioClip sound01;

    void Start()
    {　　 //　変数scoreCountにScoreCountクラスを取り込みます 
        scoreCount = gameObject.GetComponent<ScoreCount>();

        //ゲート動作用兼アイテムカウント用
        itemObj = GameObject.FindGameObjectsWithTag("item"); //  アイテムtagを持つオブジェクトをすべて取得します
        itemNum = itemObj.Length;                               //  アイテムtagを持つオブジェクトの数を取得します

        //ゲート動作用兼アイテムカウント用2
        itemLv2Obj = GameObject.FindGameObjectsWithTag("itemLv2");  // Scene内の"itemLv2"というtagをもつアイテムの数を取得します
        itemLv2Num = itemLv2Obj.Length;                         //  itemLv2というtagを持つオブジェクトの数を変数itemLv2Numに取得します

        //ゲート動作用兼アイテムカウント用2
        itemLv3Obj = GameObject.FindGameObjectsWithTag("itemLv2");  // Scene内の"itemLv2"というtagをもつアイテムの数を取得します
        itemLv3Num = itemLv2Obj.Length;                         //  itemLv2というtagを持つオブジェクトの数を変数itemLv2Numに取得します

        audioSource = GameObject.Find("AS").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)   //　当たった時のTrigger処理する関数
    {
        if (other.gameObject.tag == "item")　　	 //　もし、当たった相手のTagが"item"ならば・・
        {
            scoreCount.AddPoint(point);		 //　scoreCountのAddPointメソッドを行います
            other.gameObject.SetActive(false);   //　当たった相手の表示を止めます
            audioSource.PlayOneShot(sound01);                //  変数sound01に入っている音を1回ならします

            //ゲート動作用兼アイテムカウント用
            itemNum -= 1;            //  はじめに取得したitemの個数から1を引きます

            if (itemNum == 0)            //  もし、アイテムの個数が０ならば・・
            {
                // Gateオブジェクト内のGateMoveスクリプトにあるgateBoomフラグををtrueにします
                GameObject.Find("Gate").GetComponent<GateMove>().gateBool = true;
            }
        }

        //ゲート動作用兼アイテムカウント用2
        if (other.gameObject.tag == "itemLv2")
        //　もし当たった相手のtagが”itemLv2”なら・・
        {
            scoreCount.AddPoint(point);			 //　scoreCount内のAddPointスクリプトに飛びます
            other.gameObject.SetActive(false);		 //　その相手の表示を止めます
            itemLv2Num -= 1;				 //　scene内で集めたTagが”itemLv2Num”のオブジェクト数から1引きます
            audioSource.PlayOneShot(sound01);                //  変数sound01に入っている音を1回ならします

            if (itemLv2Num == 0)			 //　もしitemLv2Numの値が０になったら・・
            {
                //　名前が”Gate2”のオブジェクトを探して、そこにセットされたGateMoveスクリプトのgateBool変数をtrueにします
                GameObject.Find("Gate2").GetComponent<GateMove>().gateBool = true;
                //　GoalTriigerオブジェクトのBoxColliderをtrueにして　機能させます
              //  GameObject.Find("GoalTrigger").GetComponent<BoxCollider>().enabled = true;
            }
        }

        //ゲート動作用兼アイテムカウント用2
        if (other.gameObject.tag == "itemLv3")
        //　もし当たった相手のtagが”itemLv2”なら・・
        {
            scoreCount.AddPoint(point);			 //　scoreCount内のAddPointスクリプトに飛びます
            other.gameObject.SetActive(false);		 //　その相手の表示を止めます
            itemLv3Num -= 1;				 //　scene内で集めたTagが”itemLv2Num”のオブジェクト数から1引きます
            audioSource.PlayOneShot(sound01);                //  変数sound01に入っている音を1回ならします

            if (itemLv3Num == 0)			 //　もしitemLv2Numの値が０になったら・・
            {
                //　名前が”Gate2”のオブジェクトを探して、そこにセットされたGateMoveスクリプトのgateBool変数をtrueにします
                GameObject.Find("Gate3").GetComponent<GateMove>().gateBool = true;
                //　GoalTriigerオブジェクトのBoxColliderをtrueにして　機能させます
                GameObject.Find("GoalTrigger").GetComponent<BoxCollider>().enabled = true;
            }
        }

    }

}
