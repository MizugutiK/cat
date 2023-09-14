using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
  
    public float xAxis = 0f;   		  // x���̉�]
    public float yAxis = 0f;   		  // y���̉�]
    public float zAxis = 0f;   		 // z���̉�]
    public bool worldAxis = true;     // world���W���ۂ��̃t���O�ł�


    void Update()
    {
        if (worldAxis == true)�@�@ �@�@�@�@�@// ����worldAxis��true�Ȃ�΁E�E
        {	 // ���b���Ƃɐ��l�̒l����World���ŉ�]����v���O�����ł�
            transform.Rotate(new Vector3(xAxis, yAxis, zAxis) * Time.deltaTime, Space.World);
        }
        else�@//�@����ȊO�Ȃ�
        {	// ���b���Ƃɐ��l�̒l����Self�i���[�J���j��]���ŉ�]����v���O�����ł�
            transform.Rotate(new Vector3(xAxis, yAxis, zAxis) * Time.deltaTime, Space.Self);
        }
    }

}
