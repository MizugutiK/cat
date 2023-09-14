using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour
{
    private Rigidbody rigid;                  //Rigidbody�^�̕ϐ��@rigid��p�ӂ��܂�
    public float speed = 2.0f;              // ��]�X�s�[�h
    public float rad = 4.0f;                   //���a�̑傫����ϐ�rad�ɓ���܂�
    private float centerPos;                //��]���S�̈ʒu
    private float xPos;                            //x�̃|�W�V����


    void Start()
    {
        centerPos = this.gameObject.transform.position.y;   	 //  ���̃I�u�W�F�N�g�̂����W����]�̒��S�ɂ��܂�
        xPos = this.gameObject.transform.position.x;		//�@���̃I�u�W�F�N�g�̂����W��ϐ���Pos�Ɏ��܂��@	
        rigid = gameObject.AddComponent<Rigidbody>();    //�@���̃I�u�W�F�N�g��Rigidbody�R���|�l���g�������āA�ϐ�rigid�ɓ���܂�
        rigid.isKinematic = true;			 //�@rigid��IsKinematic �t���O��true�ɂ��܂�
    }


    void FixedUpdate()
    {
        //�@rigidbody��MovePosition�֐����g���A��Pos��sin�֐��ő�������l�𑫂��A��Pos �ɒ��S�ʒu��cos�֐��ő�������l�����܂�
        rigid.MovePosition(new Vector3(xPos + rad * Mathf.Sin(Time.time * speed), centerPos + rad * Mathf.Cos(Time.time * speed), 0f));
    }

}
