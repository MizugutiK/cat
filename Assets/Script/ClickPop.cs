using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPop : MonoBehaviour
{
    public float jumpPower = 5.0f;    // �W�����v�͂�p�ӂ��܂��Ainspector����������ł���悤public�ϐ��ɂ��܂�
    Rigidbody rigidBody;                     // rigidbody�^�̕ϐ�rigidBody��p�ӂ��܂�
    GameObject cursorManager;�@�@�@ // GameObject�^�̕ϐ�cursorManager��p�ӂ��܂�

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();      // �ϐ�rigidbody��rigidbody�R���|�l���g�����܂�
        cursorManager = GameObject.Find("CursorManager");	�@ // �ϐ�cursorManager�ɁhCursorManager�h�Ƃ������O��Object��T���ē���܂�

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))       //�@����Mouse�{�^����1��iMouseBottonDown�j�����ꂽ��
        {
            rigidBody.velocity = Vector3.zero;                                                                              // �������x����x���Z�b�g���܂��@(0f,0f,0f)������܂�
            rigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);                     // ��iy���j�����ɏՌ��͂������܂�
            cursorManager.GetComponent<CursorPop>().ClickVisible();�@�@ // �ϐ�cursorManager����CursorPop�X�N���v�g����ClickVisible�֐����Ăт܂�

        }
    }

}
