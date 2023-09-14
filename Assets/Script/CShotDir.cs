using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShotDir : MonoBehaviour

{
    private Image cursorImg;                                 //�N���b�N���Ɍ����cursor�̊G������ϐ�
    Vector2 mousePos;                                           //�}�E�Xposition�̈ʒu������ϐ��iUI��2�̐����ŕ\����j

    public GameObject player;�@�@// player�I�u�W�F�N�g���i�[����ϐ�player��p�ӂ��܂�
    private Vector3 forceDir;            //  �͂�������������i�[����ϐ�forceDir��p�ӂ��܂�

    public float pushPower = 5.0f;    // �����͂�p�ӂ��܂��Ainspector����������ł���悤public�ϐ��ɂ��܂�
    private Rigidbody rigidBody;       // rigidbody�^�̕ϐ�rigidBody��p�ӂ��܂�
    Ray ray;                                            //Ray�^�̕ϐ�ray
    RaycastHit hit;                                //RaycastHit�^�̕ϐ�hit�@�@Ray�����������I�u�W�F�N�g�̏��
    public Camera cam;	                //Camera�^�̕ϐ�cam��p�ӂ��܂�
    Vector3 clickHitPos;�@�@�@�@�@//�}�E�X�ŃN���b�N�����ʒu���i�[���܂�
    public bool raylineOn;                 // ray��\������O���O�iRayline�N���X����Q�Ƃ���܂��j

    //�ʔ��˗p
    public GameObject bullet;        // �e�̃I�u�W�F�N�g��p�ӂ��܂�

    void Start()
    {
        cursorImg = GameObject.Find("PopCursor").GetComponent<Image>();�@�@//�@PopCursor�I�u�W�F�N�g�ɓ����Ă���image�����܂��@
        cursorImg.enabled = false;                                                                                        //�@cursor���\���ɂ��܂�
        clickHitPos = player.transform.position;		�@//�@�܂��N���b�N�����|�W�V�����Ƃ���Player �̈ʒu�����܂�
        clickHitPos.y = -1.0f;           //�@y���̍����𒲐����邽�߂ɁA���̐��l�����Ă���܂��i�e���K�X�Ɂj        �@�@
        rigidBody = player.GetComponent<Rigidbody>();   �@ // player�I�u�W�F�N�g��rigidbody��rigidBody�ϐ��ɓ���܂�
        raylineOn = false;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�@raylineOn�t���O��false�ɂ��܂�
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        mousePos = Input.mousePosition;             //�@�}�E�X�J�[�\���̂���ʒu��ϐ�mousePos�ɓ���܂�
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 hitPos = hit.point;  //�@���������ꏊ�̍��W���i�[����ϐ�hitPos��p�ӂ���
            Debug.Log(hitPos);�@�@�@//�@���������ꏊ�̍��W��\������
            //DrawRay�iVector3�X�^�[�g���W, �����x�N�g���ƃ��C�̒����A�F �j
            Debug.DrawRay(cam.transform.position, ray.direction * 50f, Color.red);

            if (Input.GetMouseButton(0))      //�@����Mouse�{�^����1��iMouseBottonDown�j�����ꂽ��
            {
                raylineOn = true;�@�@�@�@�@�@�@�@//�@raylineOn��true�ɕς��܂�
                rigidBody.velocity = Vector3.zero;   //�@�N���b�N�������ɑ��x���O�ɂ��ē������~�߂܂�
                Vector3 playerPos = player.transform.position;       // 3D��Ԃ�Player�̈ʒu����荞�݂܂�
                cursorImg.GetComponent<RectTransform>().position = new Vector2(mousePos.x, mousePos.y);
                clickHitPos = hitPos;    �@�@�@�@�@�@//�@���̃N���b�N��������hitPosition���i�[���܂�
                clickHitPos.y = -1.0f;        //�@y���̍����𒲐����邽�߂ɁA���̐��l�����Ă���܂��i�e���K�X��

//// �����v�Z�œ��������\�b�h

                forceDir = (playerPos - clickHitPos).normalized;�@�@�@ //�N���b�N���������ւ̃x�N�g�����o���đ傫��1�ɂ��܂� 
                float angle = Mathf.Atan2(forceDir.x, forceDir.z) * Mathf.Rad2Deg;   //�������x�N�g�����p�x�ɕϊ����܂�
                                                                                     //player�I�u�W�F�N�g���N���b�N���������֌������܂�              
                transform.eulerAngles = new Vector3(forceDir.x, angle + 180, forceDir.z);
            }


            if (Input.GetMouseButtonUp(0))  �@//�@����Mouse�{�^����1��iMouseBottonDown�j�����ꂽ��
            {
                raylineOn = false; //raylineOn�t���O��false�ɂ���Ray�̕\�����~�߂܂�


        //�ʔ��˗p
                GameObject bull = Instantiate(bullet);  // prefab��bullet�I�u�W�F�N�g�𕡐����āA�ϐ�bull�ɂ���܂�
                                                        // Player�I�u�W�F�N�g�̎q�ɂ��Ă���1�Ԗڂ̃I�u�W�F�N�g��position�����܂�
                bull.transform.position = transform.GetChild(1).position;
                Rigidbody bullbody = bull.GetComponent<Rigidbody>();    // Bullet�ɂ��Ă���rigidbody��ϐ��ɓ���܂�
                                                                        // �����x�N�g�������ɏՌ��͂������܂�
                bullbody.AddForce(new Vector3(-forceDir.x * pushPower, 0f, -forceDir.z * pushPower), ForceMode.Impulse);
                Destroy(bull, 3.0f); 	// 3�b��ɕ\���������܂�
            }
        }
    }
}
