using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CursorPop : MonoBehaviour
{
    private Image cursorImg;   �@                        //cursor�̉摜������ϐ�cursorImg
    Vector2 mousePos;  �@�@                        //�}�E�Xposition�̈ʒu������ϐ�mousePos�iUI�̈ʒu��(x,y) ���W�ŕ\����j��p�ӂ���
    public float visibleTime = 0.3f;                                   // �J�[�\���\�����Ԃ����܂�


    public GameObject player;�@�@// player�I�u�W�F�N�g���i�[����ϐ�player��p�ӂ��܂�
    public Vector2 forceDir;             //  �͂�������������i�[����ϐ�forceDir��p�ӂ��܂�


    void Start()
    {
        cursorImg = GameObject.Find("PopCursor").GetComponent<Image>();       //�hPopCursor�h��T���Ă����́hImage�h��ϐ�cursorImg�ɓ����
        cursorImg.enabled = false;                                                                                        //cursorImg���\���ɂ���
        player = GameObject.Find("Player");        �@�@ 			    //"Player"�Ƃ������O�̃I�u�W�F�N�g��T���ĕϐ�player�ɓ���܂�    

    }
    void Update()
    {
        mousePos = Input.mousePosition;                 //�@�}�E�X�J�[�\���̂���ʒu��ϐ�mousePos�ɓ���܂�
        Vector3 playerPos = player.transform.position;        // 3D��Ԃ�Player�̈ʒu����荞�݂܂� �@�@�@
                                                              //�@player�̈ʒu���X�N���[�����W�ɓ��e�����QD�̍��W�ɕϊ����܂�
        Vector2 pScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, playerPos);

        //�@cursorImg�̕\��position�ʒu�ɁA�}�E�X�J�[�\����position�����܂�
        cursorImg.GetComponent<RectTransform>().position = new Vector2(mousePos.x, mousePos.y);
        //�@�ϐ�forceDir�ɃX�N���[�����Player �̈ʒu�ƃN���b�N�����J�[�\���̈ʒu�̍����狁�߂��x�N�g���𐳋K���i�P�ʃx�N�g�����j���܂�
        forceDir = (pScreenPos - new Vector2(mousePos.x, mousePos.y)).normalized;
    }



    public void ClickVisible()		//�@cursorImg��\�������郁�\�b�h�uClickVisible�i�j�v�����܂�
    {
        cursorImg.enabled = true;		//�@cursorImg��\�������܂�
        Invoke("ClickInvisible", visibleTime);                   //�@�ϐ�visibleTime�b��ɁuclickInvisible�v���Ăяo���܂�
    }


    public void ClickInvisible()		 //�@ cursorImg���\���ɂ��郁�\�b�h�uClickInvisible�i�j�v�����܂�
    {
        cursorImg.enabled = false;		 //�@cursorImg���\���ɂ��܂�
    }

}
