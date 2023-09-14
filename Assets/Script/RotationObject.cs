using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
  
    public float xAxis = 0f;   		  // x軸の回転
    public float yAxis = 0f;   		  // y軸の回転
    public float zAxis = 0f;   		 // z軸の回転
    public bool worldAxis = true;     // world座標か否かのフラグです


    void Update()
    {
        if (worldAxis == true)　　 　　　　　// もしworldAxisがtrueならば・・
        {	 // 毎秒ごとに数値の値だけWorld軸で回転するプログラムです
            transform.Rotate(new Vector3(xAxis, yAxis, zAxis) * Time.deltaTime, Space.World);
        }
        else　//　それ以外なら
        {	// 毎秒ごとに数値の値だけSelf（ローカル）回転軸で回転するプログラムです
            transform.Rotate(new Vector3(xAxis, yAxis, zAxis) * Time.deltaTime, Space.Self);
        }
    }

}
