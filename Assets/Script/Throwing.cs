using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throwing : MonoBehaviour
{
    Vector2 mousePos;                        //�}�E�Xposition�̃}�[�J�[�ʒu������ϐ��iUI��2�̐����ŕ\����j
    Ray ray;                                  �@�@ //Ray�^�̕ϐ�ray��p�ӂ��܂�
    RaycastHit hit;                     �@�@  //RaycastHit�^�̕ϐ�hit��p�ӂ��܂��i���C�����������I�u�W�F�N�g�̏��𓾂܂��j
    public GameObject player;�@�@ // player�I�u�W�F�N�g���i�[����ϐ�player��p�ӂ��܂�
    private Image cursorImg;             //�N���b�N���Ɍ����cursor�̊G�}�[�J�[������ϐ�
    private Vector3 forceDir;            //  �͂�������������i�[����ϐ�forceDir��p�ӂ��܂�
    Vector3 clickHitPos;

    public GameObject throwingObj;�@�@�@//���˂���e�̃I�u�W�F�N�g������ϐ���p�ӂ��܂�
    private Vector3 targetPos; �@�@�@�@�@//�N���b�N�����ʒu(�e�̓��B�n�_)������ϐ���p�ӂ��܂�
    public float throwingAngle;�@�@�@�@�@//�ł��グ��p�x������ϐ���p�ӂ��܂�
    private void Start()
    {
        // "PopCursor" �I�u�W�F�N�g��T���Ă����ɃZ�b�g����Ă遃Image������荞�݂܂�
        cursorImg = GameObject.Find("PopCursor").GetComponent<Image>();
        cursorImg.enabled = false;		//�@ cursorImg���\���ɂ��܂��B
        clickHitPos = player.transform.position;�@ �@//�@�͂��߂ɃN���b�N�����ꏊ��Player�̈ʒu�ɂ��Ă����܂�

        Collider collider = GetComponent<Collider>();�@	//�@ collider�����܂�
        if (collider != null)�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ //�@ collider������΁E�E
        {
            collider.isTrigger = true;�@ �@// ��������e�Ɗ����Ȃ��悤�ɂ��邽�߂ɁuisTrigger�v�ɂ��Ă����܂�
        }
    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //�ϐ�ray�Ƀ}�E�X�̃J�[�\���̏ꏊ�����܂�

        if (Physics.Raycast(ray, out hit))�@�@�@//�@ray�������ɓ������Ă�����E�E
        {
            Vector3 hitPos = hit.point;  �@�@�@�@//�@ray�����������ꏊ�̍��W���i�[����ϐ�hitPos��p�ӂ���

            if (Input.GetMouseButtonDown(1))  //�@�����}�E�X�̃N���b�N�{�^���������ꂽ��E�E
            {
                Vector3 playerPos = player.transform.position;       // 3D��Ԃ�Player�̈ʒu����荞�݂܂�
                clickHitPos = hitPos;  �@�@�@�@�@�@�@�@�@�@�@  //���̃N���b�N��������hitPosition���i�[���܂�
                mousePos = Input.mousePosition;                //�@�}�E�X�J�[�\���̏ꏊ��ϐ�mousePos�ɓ���܂�

                //// �����v�Z�œ��������\�b�h
                forceDir = (playerPos - clickHitPos).normalized;        // Player �̏ꏊ�ƃN���b�N���ꂽ�ꏊ�̍�����A�e�̌����������x�N�g�������߂܂�
                targetPos = hitPos;                       //�@ targetPos�̍��W��Ray�̍��W�����܂�

                ////mouse�̃N���b�N�}�[�N��\�������郁�\�b�h
                cursorImg.GetComponent<RectTransform>().position = new Vector2(mousePos.x, mousePos.y);
                ClickVisible();�@�@�@�@ // �N���b�N�����ꏊ�Ƀ}�[�J�[���o�����\�b�h�ɔ�т܂�
                ThrowingBurret();          // �e�𔭎˂��郁�\�b�h�֍s���܂�
            }
            ////�}�E�X�J�[�\���̈ʒu�Ƀv���C���[����]�����������镔��

            Quaternion startRot = player.transform.rotation;  //�@�N�I�^�j�I���i4�����j�^�̕ϐ�startRot�Ƀv���C���[�̉�]�p�x�̒l���i�[���܂�

            //�v���C���[�̉�]�p�x�̒l���A���̏ꏊ����e���������ցA���炩�ɉ񂵂Ă����܂�
           // player.transform.rotation = Quaternion.Slerp(startRot, Quaternion.LookRotation(-forceDir), Time.deltaTime * 5.0f);


            if (Input.GetMouseButtonUp(1))  �@�@�@�@//�@�����}�E�X�̃N���b�N�{�^���������ꂽ��E�E
            {
                ClickVisible();�@�@�@�@�@�@�@�@�@�@�@//�@�}�[�J�[��\�����郁�\�b�hClickVisible()�ɔ�т܂�
            }
        }
    }

    //// �e�𔭎Ԃ���ˏo���郁�\�b�h
    private void ThrowingBurret()
    {
        if (throwingObj != null && targetPos != null)�@//������Object�Ƒ_���ꏊ�̒l������ꍇ�́E�E
        {
            // Burret�I�u�W�F�N�g�𐶐����܂�
            GameObject bullet = Instantiate(throwingObj, this.transform.position, Quaternion.identity);

            float angle = throwingAngle;            // ���͂��ꂽ�ˏo�p�x��ϐ�angle�ɓ���܂�
                                                    //���̂ɓ�����悤�Ɏˏo���鋭���i�ˏo���x�j���v�Z����CaluculateVelocity�i���W�A�ڕW���W�A�p�x�j�ŎZ�o����X�N���v�g�ł�
            Vector3 calVelocity = CalculateVelocity(this.transform.position, targetPos, angle);

            Rigidbody rigidBody = bullet.GetComponent<Rigidbody>();      �@�@�@�@�@�@�@// �����o���e��rigidbody��ϐ��Ɋi�[���܂�
            rigidBody.AddForce(calVelocity * rigidBody.mass, ForceMode.Impulse);  �@�@�@//�v�Z���ꂽ�����̗͂��A�e�ɉ����܂�
            Destroy(bullet, 3.0f);         				�@�@�@�@ // 3�b��ɍ��ꂽ�e���󂵂܂�
        }
    }

    //�����������x���v�Z���郁�\�b�h
    private Vector3 CalculateVelocity(Vector3 posA, Vector3 posB, float angle)
    {
        float rad = angle * Mathf.PI / 180;  // �ˏo�p�����W�A���ɕϊ�

        // ���������̋���x��2�_�Ԃ��狁�߂܂�
        float x = Vector2.Distance(new Vector2(posA.x, posA.z), new Vector2(posB.x, posB.z));

        float y = posA.y - posB.y;�@�@�@ // ���������̋���y��2�_�Ԃ��狁�߂܂�

        // �Ε����˂������x�ɂ��Čv�Z���܂�
        float velo = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(velo))�@�@// �����𖞂���velo�̒l�i�����j���Ȃ���΁A�i��������1�łȂ��āA�������񂠂�΁j�E�E
        {
            return Vector3.zero;�@�@//Vector3.zero�ɂ��܂�
        }
        else�@�@�@�@�@�@�@�@�@�@//����𖞂��������l������΁E�E
        {
            return (new Vector3(posB.x - posA.x, x * Mathf.Tan(rad), posB.z - posA.z).normalized * velo);�@�@ // �����x�N�g���ɑ��xvelo���������l��Ԃ��܂�
        }
    }



    //ClickVisible�̃��\�b�h
    public void ClickVisible()
    {
        cursorImg.enabled = true;	 //�}�[�J�[�̊G��\�����܂�
        Invoke("ClickInvisible", 4.0f);�@�@ //4�b���ClickInvisible()���\�b�h�ɔ�т܂�
    }

    public void ClickInvisible()�@�@�@�@ //ClickInvisible()���\�b�h�ł�
    {
        cursorImg.enabled = false;�@�@�@ //�}�[�J�[�̊G���\���ɂ��܂�
    }
}

