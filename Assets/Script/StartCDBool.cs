using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCDBool : MonoBehaviour
{
    public GameObject startText;       // start���ɕ\������uSTART�v��GameObject�^�Ƃ��ėp�ӂ��܂�

    void Start()
    {
        startText.SetActive(true);�@�@//startText�ɓ���Ă���uSTART�v��\�����܂�
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")�@�@//�@�������������I�u�W�F�N�g��tag��Player�Ȃ�E�E
        {�@�@�@//�@GoalTrigger�Ƃ������O�̃I�u�W�F�N�g�ɓ����Ă�TimeCount�X�N���v�g��stratTime �t���O��true�ɂ��܂�
            GameObject.Find("GoalTrigger").GetComponent<CountDown>().startTime = true;
            startText.SetActive(false);�@�@//startText �ϐ��ɓ����ꂽText���\���ɂ��܂�
        }
    }

}
