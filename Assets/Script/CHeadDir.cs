using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeadDir : MonoBehaviour
{
    //   private Image cursorImg;             //クリック時に現れるcursorの絵を入れる変数
    // Vector2 mousePos;                       //マウスpositionの位置を入れる変数（UIは2つの数字で表せる）

    public GameObject player;    　　// playerオブジェクトを格納する変数playerを用意します
    private Vector3 forceDir;               //  力を加える方向を格納する変数forceDirを用意します

    public float pushPower = 5.0f;  　  // 押す力を用意します、inspectorからも調整できるようpublic変数にします
    private Rigidbody rigidBody;    　    // rigidbody型の変数rigidBodyを用意します
    Ray ray;                                       　     //レイ型の変数ray
    RaycastHit hit;                           　     //レイcastHit型の変数hit　　レイが当たったオブジェクトの情報
    public Camera cam;                  　    //Camera型の変数camを用意します
    Vector3 clickHitPos;                 　    //クリックした時のカーソル位置を入れる変数を用意します
    public bool raylineOn;               　  // rayを表示するグラグ（Raylineクラスから参照されます）

    void Start()
    {
        //   cursorImg = GameObject.Find("PopCursor").GetComponent<Image>();
        //   cursorImg.enabled = false;                                                                                        //cursorを非表示にする
        clickHitPos = player.transform.position;                   //Playerの位置を変数clickHitPosに入れておきます
        clickHitPos.y = -1.0f;                                                     //クリックした位置のｙ軸の値を-1.0にします（任意に） 
        rigidBody = player.GetComponent<Rigidbody>();    // playerオブジェクトのrigidbodyを入れます
        raylineOn = false;                                                            //rayLineをfalseにします
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //mousePos = Input.mousePosition;         //　マウスカーソルのいる位置を変数mousePosに入れます

        if (Physics.Raycast(ray, out hit))            //   もしRayが何かに当たってたら・・
        {
            Vector3 hitPos = hit.point;      //　当たった場所の座標を格納する変数hitPosを用意する

            if (Input.GetMouseButton(0))     //　もしMouseボタンが1回（MouseBottonDown）押されたら
            {
                raylineOn = true;
                rigidBody.velocity = Vector3.zero;
                Vector3 playerPos = player.transform.position;       // 3D空間のPlayerの位置を取り込みます
                                                                     //  cursorImg.GetComponent<RectTransform>().position = new Vector2(mousePos.x, mousePos.y);
                clickHitPos = hitPos;    //そのクリックした時のhitPositionを格納します
                clickHitPos.y = -1.0f;

                //// 物理計算で身体を回転させるメソッド
                forceDir = (playerPos - clickHitPos).normalized;
                float angle = Mathf.Atan2(forceDir.x, forceDir.z) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(forceDir.x, angle + 180, forceDir.z);
            }

            if (Input.GetMouseButtonUp(0)) 　　　//　もしMouseボタンが1回（MouseBottonDown）離されたら
            {
                raylineOn = false;
                rigidBody.AddForce(new Vector3(-forceDir.x * pushPower, 0f, -forceDir.z * pushPower), ForceMode.Impulse);  // 方向ベクトル方向に衝撃力を加えます
            }

            player.transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);   //　rotation（回転）は4次元数Quaternionなので、Euler角にして入れます

        }
    }
}
