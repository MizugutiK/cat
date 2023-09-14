using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathRotation : MonoBehaviour
{
    public float speed = 2f;            // 回転速度を入れる変数を用意します
    public float width = 2f;            // x軸方向の半径の大きさを入れる変数を用意します
    public float height = 2f;           // y軸方向の半径の大きさを入れる変数を用意します
    public float depth = 0f;           // z軸方向の半径の大きさを入れる変数を用意します

    private Vector3 centerPos;　// 回転の中心ポジションを入れる変数を用意します
    public float degree = 0f;       　// 位相角度（開始する位置）を入れる変数を用意します
    private float radDegree;        // 角度をラジアンに変換した価を入れる変数を用意します
    void Start()
    {
        centerPos = this.gameObject.transform.position;　　// 開始時点のアイテム位置（回転中心）にします
        radDegree = degree * Mathf.Deg2Rad;                            　 // 入力された位相角度をラジアン値に変換します
    }
    void Update()
    {
        float x = Mathf.Cos(Time.time * speed + radDegree) * width;　  // 位相0度の時にx軸が１になります、半径の大きさをかけます
        float y = Mathf.Sin(Time.time * speed + radDegree) * height;      // 位相0度の時にy軸が0になります、半径の大きさをかけます
        float z = Mathf.Sin(Time.time * speed + radDegree) * depth;    //位相0度の時にz軸が0になります、半径の大きさをかけます                                     
        transform.position = centerPos + new Vector3(x, y, z);               // 中心の位置に回転するオブジェクト位置を加えます
    }
}
