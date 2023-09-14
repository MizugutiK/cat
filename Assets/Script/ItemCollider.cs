using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    public GameObject player;       //　近づくplayerキャラを入れる変数を用意します
    private Vector3 forceDir;           //　itemが動く方向を入れる変数を入れます
    public float pushPower;             //    逃げる力の強さ

    private void OnTriggerStay(Collider other)        // 何かがTrigger範囲内に滞在していた場合・・
    {
        if (other.tag == "Player")　　　　　　　　　	　　 // もし当たった相手のtagがPlayerならば・・
        {
            Vector3 playerPos = player.transform.position; 　　　　　      // 3D空間のPlayerの位置を取り込みます
            Vector3 itemPos = this.gameObject.transform.position;   　　// このオブジェクトの位置を取り込みます
            forceDir = (playerPos - itemPos).normalized;		//　プレイヤーの位置からアイテムの位置を引いて、ベクトルを標準化します

            // 方向ベクトル方向と反対方向に「衝撃力」を加えます
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-forceDir.x * pushPower, 0f, -forceDir.z * pushPower), ForceMode.Impulse);
        }
    }
}

