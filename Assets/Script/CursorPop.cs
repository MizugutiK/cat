using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CursorPop : MonoBehaviour
{
    private Image cursorImg;   　                        //cursorの画像を入れる変数cursorImg
    Vector2 mousePos;  　　                        //マウスpositionの位置を入れる変数mousePos（UIの位置は(x,y) 座標で表せる）を用意する
    public float visibleTime = 0.3f;                                   // カーソル表示時間を入れます


    public GameObject player;　　// playerオブジェクトを格納する変数playerを用意します
    public Vector2 forceDir;             //  力を加える方向を格納する変数forceDirを用意します


    void Start()
    {
        cursorImg = GameObject.Find("PopCursor").GetComponent<Image>();       //”PopCursor”を探してそこの”Image”を変数cursorImgに入れる
        cursorImg.enabled = false;                                                                                        //cursorImgを非表示にする
        player = GameObject.Find("Player");        　　 			    //"Player"という名前のオブジェクトを探して変数playerに入れます    

    }
    void Update()
    {
        mousePos = Input.mousePosition;                 //　マウスカーソルのいる位置を変数mousePosに入れます
        Vector3 playerPos = player.transform.position;        // 3D空間のPlayerの位置を取り込みます 　　　
                                                              //　playerの位置をスクリーン座標に投影した２Dの座標に変換します
        Vector2 pScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, playerPos);

        //　cursorImgの表示position位置に、マウスカーソルのpositionを入れます
        cursorImg.GetComponent<RectTransform>().position = new Vector2(mousePos.x, mousePos.y);
        //　変数forceDirにスクリーン上のPlayer の位置とクリックしたカーソルの位置の差から求めたベクトルを正規化（単位ベクトル化）します
        forceDir = (pScreenPos - new Vector2(mousePos.x, mousePos.y)).normalized;
    }



    public void ClickVisible()		//　cursorImgを表示させるメソッド「ClickVisible（）」を作ります
    {
        cursorImg.enabled = true;		//　cursorImgを表示させます
        Invoke("ClickInvisible", visibleTime);                   //　変数visibleTime秒後に「clickInvisible」を呼び出します
    }


    public void ClickInvisible()		 //　 cursorImgを非表示にするメソッド「ClickInvisible（）」を作ります
    {
        cursorImg.enabled = false;		 //　cursorImgを非表示にします
    }

}
