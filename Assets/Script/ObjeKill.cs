using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjeKill : MonoBehaviour
{

    public ParticleSystem explosion;　	//　パーティクルの爆発を格納する変数を用意します
    private Transform otherPos;　　　	//　Transform型の変数otherPosを用意します　
    public Text Over;          		// GameOverの表示文字オブジェクトを入れる変数gameOver
    private AudioSource audioSource;    	// 音を鳴らすAudioSourceを入れます
    public AudioClip sound01;           // 爆発した時にならす音を格納する変数を用意します
    public AudioClip sound02;           // 爆発した時にならす音を格納する変数を用意します

    //// 爆発範囲の設定 

    private Rigidbody rigid;   　　//rigidbodyを格納する変数を用意します
    //public float power;                     // 吹き飛ばす爆発力
    private Vector3 expPos;             //爆発の中心ポジション
    public float rad;                           //爆発半径


    private GameObject[] itemObj;                //  scene内にあるアイテムtagを持つオブジェクトを[ ]に格納する
    private int itemNum;                                  //  アイテムtagを持つオブジェクトの数を格納する変数


    void Start()
    {
    
                                 
                                     //　AudioSourceという名前のオブジェクトを探して、そのこAudioSourceコンポネントを取得します
        audioSource = GameObject.Find("AS").GetComponent<AudioSource>();

        itemObj = GameObject.FindGameObjectsWithTag("Hiyoko"); //  アイテムtagを持つオブジェクトをすべて取得します
        itemNum = itemObj.Length;                               //  アイテムtagを持つオブジェクトの数を取得します

        Over.enabled = false;    //gameOver文字を非表示にします
    }


    void OnCollisionEnter(Collision other)			//もし何かに当たった場合
    {
        if (other.gameObject.tag == "Hiyoko")			 //それがPlayerのTagを持っていれば・・
        {
            otherPos = other.gameObject.GetComponent<Transform>();　　　　 //Transform 型の変数otherPosにその情報を入れます
            explosion.transform.position = otherPos.position;	//爆発パーティクルの位置をそのぶつかった場所にします
            explosion.Play();					//爆発を再生します
            audioSource.PlayOneShot(sound02);                //  変数sound01に入っている音を1回ならします

            other.gameObject.SetActive(false);              //　playerを非表示にします
            itemNum -= 1;            //  はじめに取得したitemの個数から1を引きます

            if (itemNum == 0)            //  もし、アイテムの個数が０ならば・・
            {
                Over.enabled = true;                                                                               //gameOver文字を表示します 

            }
        }
        if (other.gameObject.tag == "Floor")
        {
            expPos = gameObject.transform.position;             //　このオブジェクトの位置を変数expPosに入れます
            explosion.transform.position = expPos;                  //　爆発パーティクルの位置を変数expPosの位置に出します
            explosion.Play();                                                           //　爆発を再生します
            audioSource.PlayOneShot(sound01);                //  変数sound01に入っている音を1回ならします

            ////　変数expPosから半径5.0f内のすべてのコライダーを取得します
            Collider[] colliders = Physics.OverlapSphere(expPos, 5f);
            //　取得したコライダーのあるオブジェクト各1つづつ以下の処理をします
            foreach (Collider target in colliders)
            {
                //範囲内のゲームオブジェクト全てのRigidbodyにAddExplosionForceする
                if (target.GetComponent<Rigidbody>())                                   //targetにrigidbodyが付いていたら・・
                {
                    //　expPosを中心にした半径radのpowerを中心から外に向かって加えます。
               //     target.GetComponent<Rigidbody>().AddExplosionForce(power, expPos, rad);
                }
            }

            if (other.gameObject.tag == "Ene")            //それがPlayerのTagを持っていれば・・
            {
                otherPos = other.gameObject.GetComponent<Transform>();     //Transform 型の変数otherPosにその情報を入れます
                explosion.transform.position = otherPos.position;   //爆発パーティクルの位置をそのぶつかった場所にします
                explosion.Play();                   //爆発を再生します
                                                    audioSource.PlayOneShot(sound01);                //  変数sound01に入っている音を1回ならします
                other.gameObject.SetActive(false);              //　playerを非表示にします
            }
                gameObject.SetActive(false);　　　　//このゲームオブジェクトの弾を非表示にします
        }

    }
}
