using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPopDir : MonoBehaviour
{
    public float jumpPower = 5.0f;    // �W�����v�͂�p�ӂ��܂��Ainspector����������ł���悤public�ϐ��ɂ��܂�
    Rigidbody rigidBody;                   �@// rigidbody�^�̕ϐ�rigidBody��p�ӂ��܂�
    GameObject cursorManager;   // GameObject�^�̕ϐ�cursorManager��p�ӂ��܂�

    //score�Ɋւ��镶
    ScoreCount scoreCount;	//�@ ScoreCount�N���X�^�̕ϐ�scoreCount��p�ӂ��܂�
    public int point = 1;		 //�@ ���ɉ��Z�����point���P�ɂ��܂�


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();           // �ϐ�rigidbody��rigidbody�R���|�l���g�����܂�
�@�@�@// �ϐ�cursorManager��CursorManager�Ƃ������O��Object��T���Ă��ē���܂��@�@
        cursorManager = GameObject.Find("CursorManager");

        //score�Ɋւ��镶
        scoreCount = gameObject.GetComponent<ScoreCount>();  // ���̃I�u�W�F�N�g�ɂ���ScoreCoount�N���X��ϐ�scoreCount�ɓ���܂�

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //�@����Mouse�{�^����1��iMouseBottonDown�j�����ꂽ��
        {
            //�@Vector2�^�̕ϐ�fDir�ɁAcursorManager �ϐ�����CursorPop�X�N���v�g��forceDir�ϐ����Ăт܂�
            Vector2 fDir = cursorManager.GetComponent<CursorPop>().forceDir;
            rigidBody.velocity = Vector3.zero;  // �������x����x�O�����āA���݂̑��x�����Z�b�g���܂�
�@�@�@�@ // �����x�N�g��fDir.x��fDir.y������jumpPower�̒l�����������̏Ռ��͂������܂�
            rigidBody.AddForce(new Vector2(fDir.x * jumpPower, fDir.y * jumpPower), ForceMode.Impulse);
            //�@cursorManager�I�u�W�F�N�g��CursorPop�X�N���v�g��ClickVisible���\�b�h���Ăт܂��i�J�[�\���̕\���j
            cursorManager.GetComponent<CursorPop>().ClickVisible();


            //scoreCount.AddPoint(point);
            //�@scoreCount�ϐ��ɓǂݍ���AddPoint���\�b�h���Ă�ŁA�ϐ�point�̐���������܂�

        }
    }

}
