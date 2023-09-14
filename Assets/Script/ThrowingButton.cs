using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowingButton : MonoBehaviour
{
    Ray ray;                                                //レイ型の変数ray
    RaycastHit hit;                                     //レイcastHit型の変数hit　　レイが当たったオブジェクトの情報
    public GameObject player;           // playerオブジェクトを格納する変数playerを用意します

    private Vector3 forceDir;                   //  力を加える方向を格納する変数forceDirを用意します
    private Vector3 clickHitPos;            //  クリックした場所を格納する変数clickHitPosを用意します
    private Rigidbody rigid;    　　　     //　Rigodbody型の変数rigidを用意します

    public GameObject throwingObj;　　　   //弾となるオブジェクトを入れます
    public GameObject muzzle;                         // 弾を出すmuzzleをセットする変数
    public Vector3 targetPos;                           //　狙う場所を格納する変数targetPosを用意します
    public float throwingAngle;　                     //　 投げる角度を入れる変数	

    void Start()
    {
        clickHitPos = player.transform.position;    //　始めの位置としてplayerの場所を入れておきます
        rigid = player.GetComponent<Rigidbody>();           // 変数rigidに、playerオブジェクトのrigidbodyを入れます


    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);      //マウスカーソルに向かってカメラからRayを飛ばします 

        if (Physics.Raycast(ray, out hit))                                                          //Rayが何かにぶつかったら・・
        {
            Vector3 hitPos = hit.point;                     //　変数hitPosにその場所を入れます

            if (Input.GetMouseButton(1))                //　もしマウスの右クリックボタンが押されたら・・
            {
                rigid.velocity = Vector3.zero;              //  playerのrigidbodyの速度に０にして動きを止めます


                Vector3 playerPos = player.transform.position;       // 3D空間のPlayerの位置を取り込みます
                clickHitPos = hitPos;                                     //そのクリックした時のhitPositionを格納します


                //// 物理計算で動かすメソッド
                forceDir = (playerPos - clickHitPos).normalized;
                targetPos = clickHitPos;                     //　 そのクリックした時のRayの位置を目標位置に入れます


                //マウスカーソルの位置に向かせる
                Quaternion startRot = player.transform.rotation;
                player.transform.rotation = Quaternion.Slerp(startRot, Quaternion.LookRotation(-forceDir), Time.deltaTime * 5.0f);

                if (Input.GetMouseButtonUp(1))          //　もしマウスのクリックボタンが押されたら・・
                {
                    ThrowingBurret();               // 弾を発射するメソッドへ行きます

                }
            }
        }
    }

    //// 弾を発射するメソッド
    private void ThrowingBurret()
    {
       if (throwingObj != null && targetPos != null)　//投げるObjectと狙う場所のオブジェクトがある場合は・・
        {
            // Burretオブジェクトを生成します
            GameObject bullet = Instantiate(throwingObj, muzzle.transform.position, Quaternion.identity);


            float angle = throwingAngle;            // 入力された射出角度を変数angleに入れます
                                                    //ものに当たるように射出する強さ（射出速度）を計算するCaluculateVelocity（座標、目標座標、角度）で算出
            Vector3 calVelocity = CalculateVelocity(muzzle.transform.position, targetPos, angle);

            Debug.Log(calVelocity);　　//　位置確認のためのDebug.Log　（無くて良いです）
            Rigidbody rigidBody = bullet.GetComponent<Rigidbody>();      　　　// 投げ出す弾のrigidbodyを変数に格納します
            rigidBody.AddForce(calVelocity * rigidBody.mass, ForceMode.Impulse);  //計算された強さの力を、弾に加えます
                                                                                  //　どこかにある”Wakka-Parent”というオブジェクトのWakkaVisクラスにあるClickVisible()メソッドを呼び出します
            GameObject.Find("Wakka-Parent").GetComponent<WakkaVis>().ClickVisible();
            Destroy(bullet, 3.0f);          // 3秒後に弾を消します

       }
    }


    //撃ちだし速度を計算するメソッド
    private Vector3 CalculateVelocity(Vector3 posA, Vector3 posB, float angle)
    {
        float rad = angle * Mathf.PI / 180;  // 射出角をラジアンに変換

        // 水平方向の距離xを2点間から求めます
        float x = Vector2.Distance(new Vector2(posA.x, posA.z), new Vector2(posB.x, posB.z));

        // 垂直方向の距離yを2点間から求めます
        float y = posA.y - posB.y;

        // 斜方投射を初速度について計算します
        float velo = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

       
            return (new Vector3(posB.x - posA.x, x * Mathf.Tan(rad), posB.z - posA.z).normalized * velo);
        
    }
}
