using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCloseBool : MonoBehaviour
{
    public GameObject obj;				//�@�߂����Q�[�g�I�u�W�F�N�g������ϐ���p�ӂ��܂�

    void OnTriggerEnter(Collider other)			//�@�������������̃g���K�[�ɐG�ꂽ��E�E
    {
        if (other.tag == "Player")				 //�@���̃I�u�W�F�N�g��Tag���uPlayer�v�Ȃ�΁E�E
        {
            //�@�ϐ�obj�ɓ����ꂽ�I�u�W�F�N�g�ɓ����Ă�GateMove�X�N���v�g���̕ϐ�closeBool��true�ɂ��܂�
            obj.GetComponent<GateMove>().closeBool = true;
        }
    }

}
