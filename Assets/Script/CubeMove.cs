using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMove : MonoBehaviour
{
    private Rigidbody rigidBody;                 //�@���W�b�h�{�f�B������ϐ�rigidBody��p�ӂ��܂�
    public float speed = 1.0f;               //�@�i�ޑ���������ϐ�speed��p�ӂ��܂�


    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();          //�@�ϐ�rigidBody�ɂ���cube�ɂ��Ă�rigidbody�R���|�l���g������܂�    �@�@
    }

    void Update()
    {
        Vector3 forceDir = new Vector3(speed, 0, 0);		 //�@x�������̃x�N�g��������܂��Aspeed�̑傫����x�������ł�
        this.rigidBody.AddForce(forceDir, ForceMode.Force);		 //�@rigidbody�Ɍp���I�ȗ́iForce�j��speed�̕����։����܂�
    }
}
