using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakkaVis : MonoBehaviour
{
    public GameObject cursorMaker;             //�U�����Ɍ����J�[�\���̊G������ϐ�
    private Vector3 targetPos;                    // transform�^�̕ϐ�targetPos��p�ӂ��܂� 

    public void ClickVisible()		 //�Ăяo����悤��public�ɂ���ClickVisible()���\�b�h
    {�@�@//Player-01����targetPos�ϐ�������Ă��܂�
        targetPos = GameObject.Find("Player-01").GetComponent<ThrowingButton>().targetPos;
        cursorMaker.transform.position = new Vector3(targetPos.x, -1.4f, targetPos.z);�@ //�}�[�J�[�̈ʒu��targetPos�̈ʒu�ɂ��܂�
�@       cursorMaker.SetActive(true);            //�}�[�J�[�̊G��\�����܂�

        StartCoroutine("ClickInvisible");�@�@		 //�@�R���[�`����ClickInvisible���\�b�h�ɔ�т܂�
    }

    IEnumerator ClickInvisible()�@�@�@�@ //�@�R���[�`���Ŕ��ł���A�}�[�J�[���\���ɂ��邽�߂�ClickInvisible���\�b�h�ł�
    {
        yield return new WaitForSeconds(3.5f);�@ 	//�@3.5�b�ԑ҂��܂�
        cursorMaker.SetActive(false); 		//�@�}�[�J�[�̊G���\���ɂ��܂�
    }

}
