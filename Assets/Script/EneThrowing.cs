using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneThrowing : MonoBehaviour
{
    public GameObject player;�@�@ 	// player�I�u�W�F�N�g���i�[����ϐ�player��p�ӂ��܂�
    public GameObject cursorMaker;             //�U�����Ɍ����cursor�̊G�}�[�J�[������ϐ�
    private Vector3 forceDir;               //  �͂�������������i�[����ϐ�forceDir��p�ӂ��܂�

    public GameObject throwingObj;�@�@�@//���˂���e�̃I�u�W�F�N�g������ϐ���p�ӂ��܂�
    private Vector3 targetPos; �@		//����̏ꏊ������ϐ���p�ӂ��܂�
    public float throwingAngle;   		  //�ł��グ��p�x������ϐ���p�ӂ��܂�
    public GameObject muzzle;  		 // �e�𔭎˂���ꏊ�̋�I�u�W�F�N�g�̏ꏊ�����܂�
    public int rapid;                           		// �e�𔭎˂���Ԋu�̒����l
    private int i;			// �����̌v�Z�̂��߂̒l

    private void Start()
    {
        // cursorMaker�̈ʒu��player�I�u�W�F�N�g�̈ʒu�����܂�(y�̈ʒu�����n�ʂɋ߂Â��܂�)
        cursorMaker.transform.position = new Vector3(player.transform.position.x, -1.5f, player.transform.position.z);
        cursorMaker.SetActive(false);       //�@ cursorImg���\���ɂ��܂��B

        //clickHitPos = player.transform.position;   //�@�͂��߂ɃN���b�N�����ꏊ��Player�̈ʒu�ɂ��Ă����܂�
        targetPos = player.transform.position;        // player�̈ʒu��ϐ�targetPos����܂�
        forceDir = Vector3.forward;                                // ��ʒu�����߂܂�
        int i = rapid;
    }
    void Update()
    {
        ////�W�I�̈ʒu�Ɍ�������
        Quaternion startRot = player.transform.rotation;        //�񓪂��n�߂�͂��߂̊p�x���v���C���[������܂�

        //Slerp�֐��ł������A�����������܂ŉ񓪂������܂��i�n�߂̊p�x�A�������ʒu�܂ł̊p�x�A���ԁj�@�@player.transform.rotation = Quaternion.Slerp(startRot, Quaternion.LookRotation(-forceDir), Time.deltaTime * 5.0f);

        targetPos = player.transform.position;               //Player�̈ʒu����荞�݂܂�

        // Player �̏ꏊ�ƃN���b�N���ꂽ�ꏊ�̍�����A�e�̌����������x�N�g�������߂܂�
        forceDir = (targetPos - gameObject.transform.position).normalized;

        i -= 1;         //�@���t���[�����ƂɂP�Â��炵�Ă����܂�


    }
    void OnTriggerStay(Collider other)     //�@�����g���K�[�����ɉ��������݂������Ă�����
    {
        if (other.tag == "Player")�@�@�@�@�@�@�@//�@���������Tag���hPlayer�h�g�Ȃ�΁E�E
        {

            if (i <= 0)          //�@�����ĕϐ��@ i �@��0������������΁E�E        
            {
                i = rapid;			 //�@i�@�ɕϐ�rapid�̒l������܂�
                ThrowingBurret();            // �e�𔭎˂��郁�\�b�h�֍s���܂�
            }
        }

    }
    private void ThrowingBurret()
    {
        if (throwingObj != null && targetPos != null) 	//������Object�Ƒ_���ꏊ�̒l������ꍇ�́E�E
        {

            // Burret�I�u�W�F�N�g�𐶐����܂�
            GameObject bullet = Instantiate(throwingObj, muzzle.transform.position, Quaternion.identity);

            float angle = throwingAngle;            // ���͂��ꂽ�ˏo�p�x��ϐ�angle�ɓ���܂� //���̂ɓ�����悤�Ɏˏo���鋭���i�ˏo���x�j���v�Z����CaluculateVelocity�i���W�A�ڕW���W�A�p�x�j�ŎZ�o����X�N���v�g�ł�
            Vector3 calVelocity = CalculateVelocity(muzzle.transform.position, targetPos, angle);

            Rigidbody rigidBody = bullet.GetComponent<Rigidbody>();             // �����o���e��rigidbody��ϐ��Ɋi�[���܂�
            rigidBody.AddForce(calVelocity * rigidBody.mass, ForceMode.Impulse);     //�v�Z���ꂽ�����̗͂��A�e�ɉ����܂�
            Destroy(bullet, 3.0f);                           // 3�b��ɍ��ꂽ�e���󂵂܂�

            ClickVisible();     // �v���C���[�̏ꏊ�Ƀ}�[�J�[���o�����\�b�h�ɔ�т܂�
        }
    }


    ////�����������x���v�Z���郁�\�b�h
    private Vector3 CalculateVelocity(Vector3 posA, Vector3 posB, float angle)
    {
        float rad = angle * Mathf.PI / 180;  // �ˏo�p�����W�A���ɕϊ�

        // ���������̋���x��2�_�Ԃ��狁�߂܂�
        float x = Vector2.Distance(new Vector2(posA.x, posA.z), new Vector2(posB.x, posB.z));
        float y = posA.y - posB.y;    // ���������̋���y��2�_�Ԃ��狁�߂܂�

        // �Ε����˂������x�ɂ��Čv�Z���܂�
        float velo = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(velo))  // �����𖞂���velo�̒l�i�����j���Ȃ���΁A�i��������1�łȂ��āA�������񂠂�΁j�E�E
        {
            return Vector3.zero;  //Vector3.zero�ɂ��܂�
        }
        else          //����𖞂��������l������΁E�E
        {
            // �����x�N�g���ɑ��xvelo���������l��Ԃ��܂�
            return (new Vector3(posB.x - posA.x, x * Mathf.Tan(rad), posB.z - posA.z).normalized * velo);
        }
    }



    ////ClickVisible�̃��\�b�h
    public void ClickVisible()
    {
        //�@���݂̃v���C���[�̈ʒu���擾���܂�
        cursorMaker.transform.position = new Vector3(player.transform.position.x, -1.4f, player.transform.position.z);
        cursorMaker.SetActive(true);            //���̏ꏊ�ɁA�}�[�J�[�̊G��\�����܂�
        StartCoroutine("ClickInvisible");       //�R���[�`�����g���܂��AClickInvisible()���\�b�h�ɔ�т܂�
    }

    IEnumerator ClickInvisible()             //�R���[�`���ŁAClickInvisible()���\�b�h���Z�b�g���܂�
    {
        yield return new WaitForSeconds(3.5f);       //�R���[�`�����g���܂��A3.5�b�҂��܂�
        cursorMaker.SetActive(false);           //�}�[�J�[�̊G���\���ɂ��܂�
    }
}

