using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;�@�@�@	�@//�@UI�̃��W���[�����p���i�ǂݍ���Łj���Ă����܂�

public class StartBool : MonoBehaviour
{
    public Text startText;       // start���ɕ\������uSTART�v��Text�^�Ƃ��ėp�ӂ��܂�

    void Start()
    {
        startText.enabled = true;�@�@//startText�ɓ���Ă���uSTART�v��\�����܂�
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")�@�@�@�@�@�@�@�@//�@�������������I�u�W�F�N�g��tag��Player�Ȃ�E�E
        {
            //�@GoalTrigger�Ƃ������O�̃I�u�W�F�N�g�ɓ����Ă�TimeCount�X�N���v�g��stratTime �t���O��true�ɂ��܂�
            GameObject.Find("GoalTrigger").GetComponent<TimeCount>().startTime = true;
            startText.enabled = false;�@�@�@�@�@�@�@�@�@�@�@�@//startText �ϐ��ɓ����ꂽText���\���ɂ��܂�
        }
    }

}
