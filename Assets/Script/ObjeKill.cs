using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjeKill : MonoBehaviour
{

    public ParticleSystem explosion;�@	//�@�p�[�e�B�N���̔������i�[����ϐ���p�ӂ��܂�
    private Transform otherPos;�@�@�@	//�@Transform�^�̕ϐ�otherPos��p�ӂ��܂��@
    public Text Over;          		// GameOver�̕\�������I�u�W�F�N�g������ϐ�gameOver
    private AudioSource audioSource;    	// ����炷AudioSource�����܂�
    public AudioClip sound01;           // �����������ɂȂ炷�����i�[����ϐ���p�ӂ��܂�
    public AudioClip sound02;           // �����������ɂȂ炷�����i�[����ϐ���p�ӂ��܂�

    //// �����͈͂̐ݒ� 

    private Rigidbody rigid;   �@�@//rigidbody���i�[����ϐ���p�ӂ��܂�
    //public float power;                     // ������΂�������
    private Vector3 expPos;             //�����̒��S�|�W�V����
    public float rad;                           //�������a


    private GameObject[] itemObj;                //  scene���ɂ���A�C�e��tag�����I�u�W�F�N�g��[ ]�Ɋi�[����
    private int itemNum;                                  //  �A�C�e��tag�����I�u�W�F�N�g�̐����i�[����ϐ�


    void Start()
    {
    
                                 
                                     //�@AudioSource�Ƃ������O�̃I�u�W�F�N�g��T���āA���̂�AudioSource�R���|�l���g���擾���܂�
        audioSource = GameObject.Find("AS").GetComponent<AudioSource>();

        itemObj = GameObject.FindGameObjectsWithTag("Hiyoko"); //  �A�C�e��tag�����I�u�W�F�N�g�����ׂĎ擾���܂�
        itemNum = itemObj.Length;                               //  �A�C�e��tag�����I�u�W�F�N�g�̐����擾���܂�

        Over.enabled = false;    //gameOver�������\���ɂ��܂�
    }


    void OnCollisionEnter(Collision other)			//���������ɓ��������ꍇ
    {
        if (other.gameObject.tag == "Hiyoko")			 //���ꂪPlayer��Tag�������Ă���΁E�E
        {
            otherPos = other.gameObject.GetComponent<Transform>();�@�@�@�@ //Transform �^�̕ϐ�otherPos�ɂ��̏������܂�
            explosion.transform.position = otherPos.position;	//�����p�[�e�B�N���̈ʒu�����̂Ԃ������ꏊ�ɂ��܂�
            explosion.Play();					//�������Đ����܂�
            audioSource.PlayOneShot(sound02);                //  �ϐ�sound01�ɓ����Ă��鉹��1��Ȃ炵�܂�

            other.gameObject.SetActive(false);              //�@player���\���ɂ��܂�
            itemNum -= 1;            //  �͂��߂Ɏ擾����item�̌�����1�������܂�

            if (itemNum == 0)            //  �����A�A�C�e���̌����O�Ȃ�΁E�E
            {
                Over.enabled = true;                                                                               //gameOver������\�����܂� 

            }
        }
        if (other.gameObject.tag == "Floor")
        {
            expPos = gameObject.transform.position;             //�@���̃I�u�W�F�N�g�̈ʒu��ϐ�expPos�ɓ���܂�
            explosion.transform.position = expPos;                  //�@�����p�[�e�B�N���̈ʒu��ϐ�expPos�̈ʒu�ɏo���܂�
            explosion.Play();                                                           //�@�������Đ����܂�
            audioSource.PlayOneShot(sound01);                //  �ϐ�sound01�ɓ����Ă��鉹��1��Ȃ炵�܂�

            ////�@�ϐ�expPos���甼�a5.0f���̂��ׂẴR���C�_�[���擾���܂�
            Collider[] colliders = Physics.OverlapSphere(expPos, 5f);
            //�@�擾�����R���C�_�[�̂���I�u�W�F�N�g�e1�Âȉ��̏��������܂�
            foreach (Collider target in colliders)
            {
                //�͈͓��̃Q�[���I�u�W�F�N�g�S�Ă�Rigidbody��AddExplosionForce����
                if (target.GetComponent<Rigidbody>())                                   //target��rigidbody���t���Ă�����E�E
                {
                    //�@expPos�𒆐S�ɂ������arad��power�𒆐S����O�Ɍ������ĉ����܂��B
               //     target.GetComponent<Rigidbody>().AddExplosionForce(power, expPos, rad);
                }
            }

            if (other.gameObject.tag == "Ene")            //���ꂪPlayer��Tag�������Ă���΁E�E
            {
                otherPos = other.gameObject.GetComponent<Transform>();     //Transform �^�̕ϐ�otherPos�ɂ��̏������܂�
                explosion.transform.position = otherPos.position;   //�����p�[�e�B�N���̈ʒu�����̂Ԃ������ꏊ�ɂ��܂�
                explosion.Play();                   //�������Đ����܂�
                                                    audioSource.PlayOneShot(sound01);                //  �ϐ�sound01�ɓ����Ă��鉹��1��Ȃ炵�܂�
                other.gameObject.SetActive(false);              //�@player���\���ɂ��܂�
            }
                gameObject.SetActive(false);�@�@�@�@//���̃Q�[���I�u�W�F�N�g�̒e���\���ɂ��܂�
        }

    }
}
