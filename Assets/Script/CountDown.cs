using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text timeText;                        �@�@   //     �J�E���g�_�E����Text���i�[����ϐ�timeText��p��
    public float countDown = 15.00f;     �@ �@ //�@�������Ԃ����镂�������_�^�̕ϐ�countDown��p�ӂ��܂�
    public bool startTime;                      �@ �@  //�@ �J�E���g�_�E�����n�߂�t���O��p�ӂ��܂�
    private bool stopTime;                      �@�@  //     �J�E���g�_�E�����~�߂�t���O��p�ӂ��܂�
    public Text gameOver;       �@�@                 // �@GameOver�̕\�������I�u�W�F�N�g������ϐ�gameOver
    public GameObject player;                �@    //�@ player�L����������ϐ�player��p�ӂ��܂�
    public Material die;  		   //      Material�^�̕ϐ�die��p�ӂ��܂�
    public ParticleSystem smoke;       //      CountDown���Ԃɍ���Ȃ��������ɏo�����i�p�[�e�B�N���j�̕ϐ�


    void Start()
    {
        startTime = false;�@�@			//startTime�t���O��false�Ŏn�߂܂�
        timeText.text = "Time:" + countDown.ToString("f2"); 	//���̎��Ԃ̒l��Text�ŉ�2���if2�j�܂ŕ\�����܂�
        gameOver.enabled = false;           //gameOver�������\���ɂ��܂� 

    }
    void Update()
    {
        if (startTime == true)      				//�@startTime�t���O��true�Ȃ�E�E
        {
            stopTime = GetComponent<GoalBool>().glTime;  		// GoalBool�X�N���v�g��glTime�t���O���Ăт܂�
            if (stopTime == false)�@�@�@�@�@�@�@�@�@�@�@		//  ����stopTime��false�i�S�[�����ĂȂ��j�Ȃ�@�@
            {
                countDown -= Time.deltaTime;               		 //�ϐ�countDown���疈�t���[���Ԃ̎��Ԃ������Ă����܂�
                timeText.text = "Time:" + countDown.ToString("f2");     //���̎��Ԃ̒l��Text�ŉ�2���if2�j�܂ŕ\�����܂�


                if (countDown <= 0.01)�@				//����countDown�̒l��0.01�ȉ��ɂȂ�����E�E
                {
                    timeText.text = "Time:" + "0.00";           //���ԕ\����0.00��\�������܂�
                                                                //Player�I�u�W�F�N�g��CPopDir�X�N���v�g��jumpPower���\�b�h��jumpPower�̒l��0���ɂ��܂�
                    GameObject.Find("Player").GetComponent<CPopDir>().jumpPower = 0f;
                    startTime = false;              //�@�ϐ�startTime��false�ɂ���update()�ɓ���Ȃ��悤�ɂ��܂�
                    GameOver();				//�f�������n���������\�b�h�ɔ�т܂�	
                }
            }
        }
        return;   //�@�߂�܂�
    }
    public void GameOver()      //GameOver���\�b�h�ł�
    {
        gameOver.enabled = true;			�@ 	//�@GAMEOVER��text��\�����܂�
        GameObject playerOb = GameObject.Find("Player");		 //�@player�Ƃ������̃I�u�W�F�N�g��T���܂�
        playerOb.GetComponent<Renderer>().material.color = die.color;  //�@����Renderer��material��color��die�̂��̂ɂ��܂�

        //�@smoke�I�u�W�F�N�g�̈ʒu��player�I�u�W�F�N�g�̈ʒu�����܂�
        smoke.transform.position = playerOb.GetComponent<Transform>().position;
        smoke.Play();�@�@ 					//�@smoke���v���C�����܂�
        player.tag = "Untagged";        //�@player��tag���hUntagged�ɂ��܂��iGoal�ɐG��Ă�goal�\�������Ȃ����߁j

    }
}


