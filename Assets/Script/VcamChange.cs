using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;				//�@Cinemachine���p�����܂�

public class VcamChange : MonoBehaviour
{
    public CinemachineVirtualCamera vcamera;�@  //�@CinemachineVirtualCamera�^�̕ϐ���p�ӂ��܂�

    void OnTriggerEnter(Collider other)	 �@�@//�@�������g���K�[�ɓ��������ꍇ�E�E
    {
        if (other.gameObject.tag == "Player")�@ �@�@  //�@���������I�u�W�F�N�g��Tag���hPlayer�h�Ȃ�E�E
        {
            vcamera.Priority = 20;  //�ϐ�vcamera�ɓ����ꂽV�J�����̃v���C�I���e�B��20�ɂ��܂�
        }
    }

}
