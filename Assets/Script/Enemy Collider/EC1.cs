using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;　　　	　//　UIのモジュールを継承（読み込んで）しておきます

public class EC1 : MonoBehaviour
{
    public GameObject player;       //　近づくplayerキャラを入れる変数を用意します
    private Vector3 forceDir;           //　エネミーが動く方向を入れる変数を入れます
    public float pushPower;             //    追いかける速さ
    public int point = 1;

    public Text Hiyoko;
    private int H;
    void Start()
    {
        H = 0;		//　はじめに変数scoreに０を入れます　０点から始めます
    }

    void Update()
    {　//　scoreText変数に入れたスコアオブジェクトのTextを「Score:　○○（score変数に入れた数字）」と書き換えます
        Hiyoko.text = "Score:" + H.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 playerPos = player.transform.position;       // 3D空間のPlayerの位置を取り込みます
            Vector3 enemyPos = this.gameObject.transform.position;   // このオブジェクトの位置を取り込みます
            forceDir = (playerPos - enemyPos).normalized;       // 両者の位置から向かう方向ベクトルを得ます

            // 方向ベクトル方向に衝撃力を加えます
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forceDir.x * pushPower, 0f, forceDir.z * pushPower), ForceMode.Impulse);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            H = H + point;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            H = H - point;
        }
    }

}

