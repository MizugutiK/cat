using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;�@�@�@	�@//�@UI�̃��W���[�����p���i�ǂݍ���Łj���Ă����܂�

public class TimeCount : MonoBehaviour
{
    public Text timeText;     // ���Ԃ�Text�I�u�W�F�N�g���i�[����ϐ�timeText��p�ӂ��܂�
    float timeCount;              //���������_�^�̕ϐ��@timeCount��p�ӂ��܂�
    public bool stopTime;                //���v���~�߂�t���O��p�ӂ��܂�
    public bool startTime;                //���v���n�߂�t���O��p�ӂ��܂�


    private void Start()
    {
        startTime = false;  //startTime�t���O��false�ɂ��Ďn�߂܂�
    }


    void Update()
    {
        if (startTime == true)�@�@�@�@�@�@//�@startTime�t���O��true�Ȃ�iStartBool�I�u�W�F�N�g�ɐG�ꂽ�Ȃ�j�E�E
    �@   {
            //bool�ϐ�stopTime�ɁA�����I�u�W�F�N�g����GoalBool�X�N���v�g��bool�ϐ�glTime �����܂�
            stopTime = GetComponent<GoalBool>().glTime;

            if (stopTime == false)  //�@�����ϐ�stopTime�̒l���ufalse�v�Ȃ��
            {
                timeCount += Time.deltaTime;                      //�ϐ�timeCount�ɖ��t���[���Ԃ̎��Ԃ𑫂��Ă����܂�
                timeText.text = "Time:" + timeCount.ToString("f2"); //���̎��Ԃ̒l��Text�ŉ�2���if2�j�܂ŕ\�����܂�

            }
            return;
        }

    }
}
