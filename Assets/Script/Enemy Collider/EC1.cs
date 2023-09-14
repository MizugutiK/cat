using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;�@�@�@	�@//�@UI�̃��W���[�����p���i�ǂݍ���Łj���Ă����܂�

public class EC1 : MonoBehaviour
{
    public GameObject player;       //�@�߂Â�player�L����������ϐ���p�ӂ��܂�
    private Vector3 forceDir;           //�@�G�l�~�[����������������ϐ������܂�
    public float pushPower;             //    �ǂ������鑬��
    public int point = 1;

    public Text Hiyoko;
    private int H;
    void Start()
    {
        H = 0;		//�@�͂��߂ɕϐ�score�ɂO�����܂��@�O�_����n�߂܂�
    }

    void Update()
    {�@//�@scoreText�ϐ��ɓ��ꂽ�X�R�A�I�u�W�F�N�g��Text���uScore:�@�����iscore�ϐ��ɓ��ꂽ�����j�v�Ə��������܂�
        Hiyoko.text = "Score:" + H.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 playerPos = player.transform.position;       // 3D��Ԃ�Player�̈ʒu����荞�݂܂�
            Vector3 enemyPos = this.gameObject.transform.position;   // ���̃I�u�W�F�N�g�̈ʒu����荞�݂܂�
            forceDir = (playerPos - enemyPos).normalized;       // ���҂̈ʒu��������������x�N�g���𓾂܂�

            // �����x�N�g�������ɏՌ��͂������܂�
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forceDir.x * pushPower, 0f, forceDir.z * pushPower), ForceMode.Impulse);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            H = H + point;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            H = H - point;
        }
    }

}

