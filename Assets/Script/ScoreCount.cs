using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;�@�@�@	�@//�@UI�̃��W���[�����p���i�ǂݍ���Łj���Ă����܂�

public class ScoreCount : MonoBehaviour
{
    public Text scoreText;    	 // �@Text�I�u�W�F�N�g���i�[����Text�^�̕ϐ�
    private int score;               // �@�X�R�A���J�E���g���邽�߂̕ϐ�score��p�ӂ��܂�

    void Start()
    {
        score = 0;		//�@�͂��߂ɕϐ�score�ɂO�����܂��@�O�_����n�߂܂�
    }

    void Update()
    {�@//�@scoreText�ϐ��ɓ��ꂽ�X�R�A�I�u�W�F�N�g��Text���uScore:�@�����iscore�ϐ��ɓ��ꂽ�����j�v�Ə��������܂�
        scoreText.text = "Score:" + score.ToString();
    }

    public void AddPoint(int point)�@�@	//�@�uAddPoint�v�Ƃ���������int�^�̕ϐ��������������\�b�h�����܂�
    {
        score = score + point;�@�@�@�@	//�@���̃��\�b�h���Ă񂾂�Ascore�ϐ��ɕϐ�point�ɓ����ꂽ�����������܂�
    }
}
