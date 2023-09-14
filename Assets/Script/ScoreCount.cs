using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;　　　	　//　UIのモジュールを継承（読み込んで）しておきます

public class ScoreCount : MonoBehaviour
{
    public Text scoreText;    	 // 　Textオブジェクトを格納するText型の変数
    private int score;               // 　スコアをカウントするための変数scoreを用意します

    void Start()
    {
        score = 0;		//　はじめに変数scoreに０を入れます　０点から始めます
    }

    void Update()
    {　//　scoreText変数に入れたスコアオブジェクトのTextを「Score:　○○（score変数に入れた数字）」と書き換えます
        scoreText.text = "Score:" + score.ToString();
    }

    public void AddPoint(int point)　　	//　「AddPoint」という引数にint型の変数を持たせたメソッドを作ります
    {
        score = score + point;　　　　	//　このメソッドを呼んだら、score変数に変数pointに入れられた数字を加えます
    }
}
