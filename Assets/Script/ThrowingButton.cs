using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowingButton : MonoBehaviour
{
    Ray ray;                                                //���C�^�̕ϐ�ray
    RaycastHit hit;                                     //���CcastHit�^�̕ϐ�hit�@�@���C�����������I�u�W�F�N�g�̏��
    public GameObject player;           // player�I�u�W�F�N�g���i�[����ϐ�player��p�ӂ��܂�

    private Vector3 forceDir;                   //  �͂�������������i�[����ϐ�forceDir��p�ӂ��܂�
    private Vector3 clickHitPos;            //  �N���b�N�����ꏊ���i�[����ϐ�clickHitPos��p�ӂ��܂�
    private Rigidbody rigid;    �@�@�@     //�@Rigodbody�^�̕ϐ�rigid��p�ӂ��܂�

    public GameObject throwingObj;�@�@�@   //�e�ƂȂ�I�u�W�F�N�g�����܂�
    public GameObject muzzle;                         // �e���o��muzzle���Z�b�g����ϐ�
    public Vector3 targetPos;                           //�@�_���ꏊ���i�[����ϐ�targetPos��p�ӂ��܂�
    public float throwingAngle;�@                     //�@ ������p�x������ϐ�	

    void Start()
    {
        clickHitPos = player.transform.position;    //�@�n�߂̈ʒu�Ƃ���player�̏ꏊ�����Ă����܂�
        rigid = player.GetComponent<Rigidbody>();           // �ϐ�rigid�ɁAplayer�I�u�W�F�N�g��rigidbody�����܂�


    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);      //�}�E�X�J�[�\���Ɍ������ăJ��������Ray���΂��܂� 

        if (Physics.Raycast(ray, out hit))                                                          //Ray�������ɂԂ�������E�E
        {
            Vector3 hitPos = hit.point;                     //�@�ϐ�hitPos�ɂ��̏ꏊ�����܂�

            if (Input.GetMouseButton(1))                //�@�����}�E�X�̉E�N���b�N�{�^���������ꂽ��E�E
            {
                rigid.velocity = Vector3.zero;              //  player��rigidbody�̑��x�ɂO�ɂ��ē������~�߂܂�


                Vector3 playerPos = player.transform.position;       // 3D��Ԃ�Player�̈ʒu����荞�݂܂�
                clickHitPos = hitPos;                                     //���̃N���b�N��������hitPosition���i�[���܂�


                //// �����v�Z�œ��������\�b�h
                forceDir = (playerPos - clickHitPos).normalized;
                targetPos = clickHitPos;                     //�@ ���̃N���b�N��������Ray�̈ʒu��ڕW�ʒu�ɓ���܂�


                //�}�E�X�J�[�\���̈ʒu�Ɍ�������
                Quaternion startRot = player.transform.rotation;
                player.transform.rotation = Quaternion.Slerp(startRot, Quaternion.LookRotation(-forceDir), Time.deltaTime * 5.0f);

                if (Input.GetMouseButtonUp(1))          //�@�����}�E�X�̃N���b�N�{�^���������ꂽ��E�E
                {
                    ThrowingBurret();               // �e�𔭎˂��郁�\�b�h�֍s���܂�

                }
            }
        }
    }

    //// �e�𔭎˂��郁�\�b�h
    private void ThrowingBurret()
    {
       if (throwingObj != null && targetPos != null)�@//������Object�Ƒ_���ꏊ�̃I�u�W�F�N�g������ꍇ�́E�E
        {
            // Burret�I�u�W�F�N�g�𐶐����܂�
            GameObject bullet = Instantiate(throwingObj, muzzle.transform.position, Quaternion.identity);


            float angle = throwingAngle;            // ���͂��ꂽ�ˏo�p�x��ϐ�angle�ɓ���܂�
                                                    //���̂ɓ�����悤�Ɏˏo���鋭���i�ˏo���x�j���v�Z����CaluculateVelocity�i���W�A�ڕW���W�A�p�x�j�ŎZ�o
            Vector3 calVelocity = CalculateVelocity(muzzle.transform.position, targetPos, angle);

            Debug.Log(calVelocity);�@�@//�@�ʒu�m�F�̂��߂�Debug.Log�@�i�����ėǂ��ł��j
            Rigidbody rigidBody = bullet.GetComponent<Rigidbody>();      �@�@�@// �����o���e��rigidbody��ϐ��Ɋi�[���܂�
            rigidBody.AddForce(calVelocity * rigidBody.mass, ForceMode.Impulse);  //�v�Z���ꂽ�����̗͂��A�e�ɉ����܂�
                                                                                  //�@�ǂ����ɂ���hWakka-Parent�h�Ƃ����I�u�W�F�N�g��WakkaVis�N���X�ɂ���ClickVisible()���\�b�h���Ăяo���܂�
            GameObject.Find("Wakka-Parent").GetComponent<WakkaVis>().ClickVisible();
            Destroy(bullet, 3.0f);          // 3�b��ɒe�������܂�

       }
    }


    //�����������x���v�Z���郁�\�b�h
    private Vector3 CalculateVelocity(Vector3 posA, Vector3 posB, float angle)
    {
        float rad = angle * Mathf.PI / 180;  // �ˏo�p�����W�A���ɕϊ�

        // ���������̋���x��2�_�Ԃ��狁�߂܂�
        float x = Vector2.Distance(new Vector2(posA.x, posA.z), new Vector2(posB.x, posB.z));

        // ���������̋���y��2�_�Ԃ��狁�߂܂�
        float y = posA.y - posB.y;

        // �Ε����˂������x�ɂ��Čv�Z���܂�
        float velo = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

       
            return (new Vector3(posB.x - posA.x, x * Mathf.Tan(rad), posB.z - posA.z).normalized * velo);
        
    }
}
