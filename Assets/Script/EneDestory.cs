using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneDestory : MonoBehaviour
{
	public int life = 3;             // �G�l�~�[�̗̑͂�����ϐ���p�ӂ��܂�

	private void OnCollisionEnter(Collision other)   // �����A�����ƐڐG������
	{
		if (other.gameObject.tag == "Bullet")   // ���̐ڐG�����I�u�W�F�N�g��Tag���hBullet�h�Ȃ��
		{
			life -= 1;           // �ϐ�life����1�����܂�
			if (life <= 0)           // �ϐ�life�̒l��0�ȉ��ɂȂ�����
			{
				gameObject.SetActive(false);     // ���̃I�u�W�F�N�g���\���ɂ��܂�
			}
		}
	}

}
