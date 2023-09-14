using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    public GameObject player;       //�@�߂Â�player�L����������ϐ���p�ӂ��܂�
    private Vector3 forceDir;           //�@item����������������ϐ������܂�
    public float pushPower;             //    ������͂̋���

    private void OnTriggerStay(Collider other)        // ������Trigger�͈͓��ɑ؍݂��Ă����ꍇ�E�E
    {
        if (other.tag == "Player")�@�@�@�@�@�@�@�@�@	�@�@ // �����������������tag��Player�Ȃ�΁E�E
        {
            Vector3 playerPos = player.transform.position; �@�@�@�@�@      // 3D��Ԃ�Player�̈ʒu����荞�݂܂�
            Vector3 itemPos = this.gameObject.transform.position;   �@�@// ���̃I�u�W�F�N�g�̈ʒu����荞�݂܂�
            forceDir = (playerPos - itemPos).normalized;		//�@�v���C���[�̈ʒu����A�C�e���̈ʒu�������āA�x�N�g����W�������܂�

            // �����x�N�g�������Ɣ��Ε����Ɂu�Ռ��́v�������܂�
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-forceDir.x * pushPower, 0f, -forceDir.z * pushPower), ForceMode.Impulse);
        }
    }
}

