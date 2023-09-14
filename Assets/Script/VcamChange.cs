using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;				//　Cinemachineを継承します

public class VcamChange : MonoBehaviour
{
    public CinemachineVirtualCamera vcamera;　  //　CinemachineVirtualCamera型の変数を用意します

    void OnTriggerEnter(Collider other)	 　　//　何かがトリガーに当たった場合・・
    {
        if (other.gameObject.tag == "Player")　 　　  //　当たったオブジェクトのTagが”Player”なら・・
        {
            vcamera.Priority = 20;  //変数vcameraに入れられたVカメラのプライオリティを20にします
        }
    }

}
