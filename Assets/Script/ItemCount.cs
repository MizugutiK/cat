using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCount : MonoBehaviour
{
    ScoreCount scoreCount;		//�@ScoreCount�^�̕ϐ��@scoreCount������܂�
    public int point = 1;        //�@�������|�C���g�̒l������ϐ�point��p�ӂ��܂�

    //�Q�[�g����p���A�C�e���J�E���g�p
    private GameObject[] itemObj;                //  scene���ɂ���A�C�e��tag�����I�u�W�F�N�g��[ ]�Ɋi�[����
    private int itemNum;                                  //  �A�C�e��tag�����I�u�W�F�N�g�̐����i�[����ϐ�

 //�Q�[�g����p���A�C�e���J�E���g�p2
    private GameObject[] itemLv2Obj;            //  scene���ɂ���A�C�e��Lv2tag�����I�u�W�F�N�g���u�v�Ɋi�[����
    private int itemLv2Num;                             //  �A�C�e��Lv2tag�����I�u�W�F�N�g�̐����i�[����ϐ�

    //�Q�[�g����p���A�C�e���J�E���g�p2
    private GameObject[] itemLv3Obj;            //  scene���ɂ���A�C�e��Lv2tag�����I�u�W�F�N�g���u�v�Ɋi�[����
    private int itemLv3Num;                             //  �A�C�e��Lv2tag�����I�u�W�F�N�g�̐����i�[����ϐ�

    public AudioSource audioSource;	//�@����炷�V�X�e��AudioSource��p�ӂ��܂�
    public AudioClip sound01;

    void Start()
    {�@�@ //�@�ϐ�scoreCount��ScoreCount�N���X����荞�݂܂� 
        scoreCount = gameObject.GetComponent<ScoreCount>();

        //�Q�[�g����p���A�C�e���J�E���g�p
        itemObj = GameObject.FindGameObjectsWithTag("item"); //  �A�C�e��tag�����I�u�W�F�N�g�����ׂĎ擾���܂�
        itemNum = itemObj.Length;                               //  �A�C�e��tag�����I�u�W�F�N�g�̐����擾���܂�

        //�Q�[�g����p���A�C�e���J�E���g�p2
        itemLv2Obj = GameObject.FindGameObjectsWithTag("itemLv2");  // Scene����"itemLv2"�Ƃ���tag�����A�C�e���̐����擾���܂�
        itemLv2Num = itemLv2Obj.Length;                         //  itemLv2�Ƃ���tag�����I�u�W�F�N�g�̐���ϐ�itemLv2Num�Ɏ擾���܂�

        //�Q�[�g����p���A�C�e���J�E���g�p2
        itemLv3Obj = GameObject.FindGameObjectsWithTag("itemLv2");  // Scene����"itemLv2"�Ƃ���tag�����A�C�e���̐����擾���܂�
        itemLv3Num = itemLv2Obj.Length;                         //  itemLv2�Ƃ���tag�����I�u�W�F�N�g�̐���ϐ�itemLv2Num�Ɏ擾���܂�

        audioSource = GameObject.Find("AS").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)   //�@������������Trigger��������֐�
    {
        if (other.gameObject.tag == "item")�@�@	 //�@�����A�������������Tag��"item"�Ȃ�΁E�E
        {
            scoreCount.AddPoint(point);		 //�@scoreCount��AddPoint���\�b�h���s���܂�
            other.gameObject.SetActive(false);   //�@������������̕\�����~�߂܂�
            audioSource.PlayOneShot(sound01);                //  �ϐ�sound01�ɓ����Ă��鉹��1��Ȃ炵�܂�

            //�Q�[�g����p���A�C�e���J�E���g�p
            itemNum -= 1;            //  �͂��߂Ɏ擾����item�̌�����1�������܂�

            if (itemNum == 0)            //  �����A�A�C�e���̌����O�Ȃ�΁E�E
            {
                // Gate�I�u�W�F�N�g����GateMove�X�N���v�g�ɂ���gateBoom�t���O����true�ɂ��܂�
                GameObject.Find("Gate").GetComponent<GateMove>().gateBool = true;
            }
        }

        //�Q�[�g����p���A�C�e���J�E���g�p2
        if (other.gameObject.tag == "itemLv2")
        //�@�����������������tag���hitemLv2�h�Ȃ�E�E
        {
            scoreCount.AddPoint(point);			 //�@scoreCount����AddPoint�X�N���v�g�ɔ�т܂�
            other.gameObject.SetActive(false);		 //�@���̑���̕\�����~�߂܂�
            itemLv2Num -= 1;				 //�@scene���ŏW�߂�Tag���hitemLv2Num�h�̃I�u�W�F�N�g������1�����܂�
            audioSource.PlayOneShot(sound01);                //  �ϐ�sound01�ɓ����Ă��鉹��1��Ȃ炵�܂�

            if (itemLv2Num == 0)			 //�@����itemLv2Num�̒l���O�ɂȂ�����E�E
            {
                //�@���O���hGate2�h�̃I�u�W�F�N�g��T���āA�����ɃZ�b�g���ꂽGateMove�X�N���v�g��gateBool�ϐ���true�ɂ��܂�
                GameObject.Find("Gate2").GetComponent<GateMove>().gateBool = true;
                //�@GoalTriiger�I�u�W�F�N�g��BoxCollider��true�ɂ��ā@�@�\�����܂�
              //  GameObject.Find("GoalTrigger").GetComponent<BoxCollider>().enabled = true;
            }
        }

        //�Q�[�g����p���A�C�e���J�E���g�p2
        if (other.gameObject.tag == "itemLv3")
        //�@�����������������tag���hitemLv2�h�Ȃ�E�E
        {
            scoreCount.AddPoint(point);			 //�@scoreCount����AddPoint�X�N���v�g�ɔ�т܂�
            other.gameObject.SetActive(false);		 //�@���̑���̕\�����~�߂܂�
            itemLv3Num -= 1;				 //�@scene���ŏW�߂�Tag���hitemLv2Num�h�̃I�u�W�F�N�g������1�����܂�
            audioSource.PlayOneShot(sound01);                //  �ϐ�sound01�ɓ����Ă��鉹��1��Ȃ炵�܂�

            if (itemLv3Num == 0)			 //�@����itemLv2Num�̒l���O�ɂȂ�����E�E
            {
                //�@���O���hGate2�h�̃I�u�W�F�N�g��T���āA�����ɃZ�b�g���ꂽGateMove�X�N���v�g��gateBool�ϐ���true�ɂ��܂�
                GameObject.Find("Gate3").GetComponent<GateMove>().gateBool = true;
                //�@GoalTriiger�I�u�W�F�N�g��BoxCollider��true�ɂ��ā@�@�\�����܂�
                GameObject.Find("GoalTrigger").GetComponent<BoxCollider>().enabled = true;
            }
        }

    }

}
