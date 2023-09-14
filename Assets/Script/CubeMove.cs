using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMove : MonoBehaviour
{
    private Rigidbody rigidBody;                 //　リジッドボディを入れる変数rigidBodyを用意します
    public float speed = 1.0f;               //　進む速さを入れる変数speedを用意します


    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();          //　変数rigidBodyにこのcubeについていrigidbodyコンポネントをいれます    　　
    }

    void Update()
    {
        Vector3 forceDir = new Vector3(speed, 0, 0);		 //　x軸方向のベクトルをつくります、speedの大きさでx軸方向です
        this.rigidBody.AddForce(forceDir, ForceMode.Force);		 //　rigidbodyに継続的な力（Force）をspeedの方向へ加えます
    }
}
