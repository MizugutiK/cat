using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeadDir : MonoBehaviour
{
    //   private Image cursorImg;             //�N���b�N���Ɍ����cursor�̊G������ϐ�
    // Vector2 mousePos;                       //�}�E�Xposition�̈ʒu������ϐ��iUI��2�̐����ŕ\����j

    public GameObject player;    �@�@// player�I�u�W�F�N�g���i�[����ϐ�player��p�ӂ��܂�
    private Vector3 forceDir;               //  �͂�������������i�[����ϐ�forceDir��p�ӂ��܂�

    public float pushPower = 5.0f;  �@  // �����͂�p�ӂ��܂��Ainspector����������ł���悤public�ϐ��ɂ��܂�
    private Rigidbody rigidBody;    �@    // rigidbody�^�̕ϐ�rigidBody��p�ӂ��܂�
    Ray ray;                                       �@     //���C�^�̕ϐ�ray
    RaycastHit hit;                           �@     //���CcastHit�^�̕ϐ�hit�@�@���C�����������I�u�W�F�N�g�̏��
    public Camera cam;                  �@    //Camera�^�̕ϐ�cam��p�ӂ��܂�
    Vector3 clickHitPos;                 �@    //�N���b�N�������̃J�[�\���ʒu������ϐ���p�ӂ��܂�
    public bool raylineOn;               �@  // ray��\������O���O�iRayline�N���X����Q�Ƃ���܂��j

    void Start()
    {
        //   cursorImg = GameObject.Find("PopCursor").GetComponent<Image>();
        //   cursorImg.enabled = false;                                                                                        //cursor���\���ɂ���
        clickHitPos = player.transform.position;                   //Player�̈ʒu��ϐ�clickHitPos�ɓ���Ă����܂�
        clickHitPos.y = -1.0f;                                                     //�N���b�N�����ʒu�̂����̒l��-1.0�ɂ��܂��i�C�ӂɁj 
        rigidBody = player.GetComponent<Rigidbody>();    // player�I�u�W�F�N�g��rigidbody�����܂�
        raylineOn = false;                                                            //rayLine��false�ɂ��܂�
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //mousePos = Input.mousePosition;         //�@�}�E�X�J�[�\���̂���ʒu��ϐ�mousePos�ɓ���܂�

        if (Physics.Raycast(ray, out hit))            //   ����Ray�������ɓ������Ă���E�E
        {
            Vector3 hitPos = hit.point;      //�@���������ꏊ�̍��W���i�[����ϐ�hitPos��p�ӂ���

            if (Input.GetMouseButton(0))     //�@����Mouse�{�^����1��iMouseBottonDown�j�����ꂽ��
            {
                raylineOn = true;
                rigidBody.velocity = Vector3.zero;
                Vector3 playerPos = player.transform.position;       // 3D��Ԃ�Player�̈ʒu����荞�݂܂�
                                                                     //  cursorImg.GetComponent<RectTransform>().position = new Vector2(mousePos.x, mousePos.y);
                clickHitPos = hitPos;    //���̃N���b�N��������hitPosition���i�[���܂�
                clickHitPos.y = -1.0f;

                //// �����v�Z�Őg�̂���]�����郁�\�b�h
                forceDir = (playerPos - clickHitPos).normalized;
                float angle = Mathf.Atan2(forceDir.x, forceDir.z) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(forceDir.x, angle + 180, forceDir.z);
            }

            if (Input.GetMouseButtonUp(0)) �@�@�@//�@����Mouse�{�^����1��iMouseBottonDown�j�����ꂽ��
            {
                raylineOn = false;
                rigidBody.AddForce(new Vector3(-forceDir.x * pushPower, 0f, -forceDir.z * pushPower), ForceMode.Impulse);  // �����x�N�g�������ɏՌ��͂������܂�
            }

            player.transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);   //�@rotation�i��]�j��4������Quaternion�Ȃ̂ŁAEuler�p�ɂ��ē���܂�

        }
    }
}
