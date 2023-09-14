using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathRotation : MonoBehaviour
{
    public float speed = 2f;            // ��]���x������ϐ���p�ӂ��܂�
    public float width = 2f;            // x�������̔��a�̑傫��������ϐ���p�ӂ��܂�
    public float height = 2f;           // y�������̔��a�̑傫��������ϐ���p�ӂ��܂�
    public float depth = 0f;           // z�������̔��a�̑傫��������ϐ���p�ӂ��܂�

    private Vector3 centerPos;�@// ��]�̒��S�|�W�V����������ϐ���p�ӂ��܂�
    public float degree = 0f;       �@// �ʑ��p�x�i�J�n����ʒu�j������ϐ���p�ӂ��܂�
    private float radDegree;        // �p�x�����W�A���ɕϊ�������������ϐ���p�ӂ��܂�
    void Start()
    {
        centerPos = this.gameObject.transform.position;�@�@// �J�n���_�̃A�C�e���ʒu�i��]���S�j�ɂ��܂�
        radDegree = degree * Mathf.Deg2Rad;                            �@ // ���͂��ꂽ�ʑ��p�x�����W�A���l�ɕϊ����܂�
    }
    void Update()
    {
        float x = Mathf.Cos(Time.time * speed + radDegree) * width;�@  // �ʑ�0�x�̎���x�����P�ɂȂ�܂��A���a�̑傫���������܂�
        float y = Mathf.Sin(Time.time * speed + radDegree) * height;      // �ʑ�0�x�̎���y����0�ɂȂ�܂��A���a�̑傫���������܂�
        float z = Mathf.Sin(Time.time * speed + radDegree) * depth;    //�ʑ�0�x�̎���z����0�ɂȂ�܂��A���a�̑傫���������܂�                                     
        transform.position = centerPos + new Vector3(x, y, z);               // ���S�̈ʒu�ɉ�]����I�u�W�F�N�g�ʒu�������܂�
    }
}
