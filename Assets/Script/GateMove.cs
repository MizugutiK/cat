using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMove : MonoBehaviour
{
    public bool gateBool;�@�@�@�@�@�@�@	//�@Gate�𓮂����t���O��gateBool��p�ӂ��܂��@
    public float maxHeight = 10.0f;       //�@�Q�[�g�𓮂����ő�̍��������߂Ă����܂�

    //�Q�[�g�����Ƃɖ߂��悤
    private Vector3 oriPos;         // ���̈ʒu���i�[���Ă����ϐ���p�ӂ��܂� 
    public bool closeBool;          // �Q�[�g��߂�t���O��p�ӂ��܂��@

    void Start()
    {
        gateBool = false;            //�@Gate�t���O��false�ɂ��Ă����܂�

  �@�@//�Q�[�g�����Ƃɖ߂��悤
        oriPos = gameObject.transform.position;     �@�@//�͂��܂�̃Q�[�g�|�W�V�������擾���Ă����܂��@
        closeBool = false;                                                      //�Q�[�g��߂�t���O��false�ɂ��Ă����܂�

    }


    void Update()
    {
        if (gateBool == true) 		 	//�@�����AgateBool�t���O��true�Ȃ�΁E�E
        {
            maxHeight -= 0.1f;		 	//�@�Q�[�g�̍ő�ړ���������0.1�Â��炵�Ă����܂�
            this.transform.position += new Vector3(0f, 0.1f, 0f);�@ //�@���̃I�u�W�F�N�g�̂��|�W�V������0.1�Â����Ă����܂�
            if (maxHeight <= 0.0f)			 //�@�����ő�ړ������̒l��0�ɂȂ�����E�E
            {
                gateBool = false;			 //�@��ateBool�t���O��false�ɂ��āA�ړ����~�߂܂�
            }
        }
        //�Q�[�g�����Ƃɖ߂��悤
        if (gateBool == false & closeBool == true)                          //����gateBool��false��closeBool��true�̎��ɂ�
        {
            this.transform.position -= new Vector3(0f, 0.1f, 0f);�@//���̃I�u�W�F�N�g�̂��̒l����0.1�Â����čs���܂�
            if (transform.position.y - oriPos.y <= 0.1f)                      //�����n�߂̈ʒuoriPos�Ƃ̍���0.1�ȉ��ɂȂ�����E�E
            {
                closeBool = false;                                                           //closeBool�t���O��false�ɖ߂��܂�
            }
        }

    }
}
