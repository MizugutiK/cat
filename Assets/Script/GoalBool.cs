using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalBool : MonoBehaviour
{
    public bool glTime;               �@�@ // ���v���~�߂�t���O��p�ӂ��܂�
    public Text goalText;          // goal���ɕ\������uGoal�v��Text�^�Ƃ��ėp�ӂ��܂�

    private void Start()
    {
        goalText.enabled = false;   //�@goalText��GOALText���\���ɂ��܂�
        glTime = false;       //�@�t���O�ϐ�glTime��false�ɂ��āA���v���~�߂Ȃ��l�ɂ��܂�
    }

    private void OnTriggerEnter(Collider other) //�@Trigger�ɐG�ꂽ���̏���
    {
        if (other.gameObject.tag == "Player")	//�@���������������Tag���hPlayer�h�Ȃ�E�E
        {
            glTime = true;          //�@�t���O�̕ϐ�glTime��true(�^)�ɂ��܂�
            goalText.enabled = true;         //�@GOAL�̕�����\�������܂�

            //�J�����p�̕�
            GetComponent<BoxCollider>().enabled = false;  �@//�@�J�n���ɃR���C�_�[�������Ă����܂��i����������������True�ɂ��܂��j

            //����ł��Ȃ��悤�ɂ��邽�߂̕��Ƃ��@
         //   GameObject.Find("Player").GetComponent<CPopDir>().jumpPower = 0f; // CPopDir�X�N���v�g��jumpPower���O�ɂ��܂�
        //   GameObject.Find("Player").GetComponent<ThrowingButton>().tag = "Untagged";�@�@ // Player��tag��Untagged�ɂ��܂�
     

        }
    }
}