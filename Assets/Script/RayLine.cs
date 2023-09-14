using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLine : MonoBehaviour
{
    public int rayBounce;                       �@   //Ray���ǂɔ��˂���񐔂����܂�
    public float maxLength;                          //Line�̍ő咷�������܂�

    private LineRenderer lineRenderer;�@�@//lineRenderer���i�[����ϐ���p�ӂ��܂�
    private Ray ray;                                     �@   //Ray�^�̕ϐ���p�ӂ��܂�
    private RaycastHit hit;                             //Ray�̓��������I�u�W�F�N�g�̕ϐ���p��
    private bool rayOn;                                     // ray��\�����邩�A�\�����Ȃ����̃t���O�ł�


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();          // Linerender�^�̕ϐ���LineRederer�R���|�l���g�����܂�
        rayOn = gameObject.GetComponent<CShotDir>().raylineOn;                 //ray��\������t���O��CSHotDir�������Ă��܂�

    }
    void Update()
    {
        rayOn = gameObject.GetComponent<CShotDir>().raylineOn;                 //ray��\������t���O��CSHotDir�������Ă��܂�


        if (rayOn == true)				�@�@�@�@�@ //�@����rayOn�t���O��true�Ȃ�΁E�E
        {
            ray = new Ray(transform.position, transform.forward);   �@�@�@�@    //�@Ray�̐���E�E�V�������̃I�u�W�F�N�g����Az��������Ray���o���܂�
            lineRenderer.positionCount = 1;                                 �@�@�@�@�@�@      //�@lineRenderer�ϐ���positionCount�i���_�̐��j��1�����܂�
            lineRenderer.SetPosition(0, transform.position);  �@�@�@�@�@�@�@�@//�@lineRenderer�֐���0�n�_����v���C���[�̈ʒu�܂Ő���`���܂�
            float leftLength = maxLength;                                           �@�@�@�@�@�@//�@�ϐ�leftLength�ɍő咷���̒l�����܂�

            for (int i = 0; i < rayBounce; i++)                                      �@�@�@�@  �@  //�@�ϐ�rayBounce�ɓ��ꐂ�ꂽ�񐔂������[�v�����܂�
            {
                ////�����ARaycast��Object�ɓ���������E�E�iRay�̊J�n�_Vector3�ARay�̕���Vector3�A�q�b�g�����I�u�W�F�N�g�̏��Aray�̒����j
                if (Physics.Raycast(ray.origin, ray.direction, out hit, leftLength))
                {
                    lineRenderer.positionCount += 1;                      �@      �@�@�@�@//�@lineRenderer��positionCount��1�𑫂��܂�
                    {
                        //�@�����������_����P�O�̈ʒu����A���������ꏊ�܂Ő��������܂��@
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                        //�@�ő咷������ray�̔��Ԃ��ꂽ�ꏊ���瓖�������ꏊ�܂ł̋����������܂�
                        leftLength -= Vector3.Distance(ray.origin, hit.point);

                        //�@�ϐ�ray�ɁA�V�������������ꏊ����A���˂��������ɏo��ray�����܂��iReflect�֐��́u���ˁv���v�Z���Ă���܂��j
                        ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

                        if (hit.collider.tag != "Wall") 	 //�@������������collider��tag���hWall�h�@�łȂ���΁@(���˂��������ǂ�Wall�Ƃ���tag���Z�b�g���܂�)
                        {
                            break;                                  //�I���܂�
                        }
                        else            �@�@�@�@�@�@//�������́E�E�@�@�@�@
                        {
                            //�ǂɓ������Ă����lineRenderer�ϐ���positionCount�i���_�̐��j��1�𑫂��܂�
                            lineRenderer.positionCount += 1;

                            //�ЂƂO�̒��_����Aray�̂͂��܂�̒n�_����c���ray�̒����𑫂��������֐���`���܂�
                            lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * leftLength);
                        }
                    }
                }
            }
        }
        else if (rayOn == false)	�@�@�@�@�@�@�@�@�@//�@rayOn��false�Ȃ�΁E�E�E
        {
            lineRenderer.positionCount = 0;                                       //lineRenderer�ϐ���positionCount�i���_�̐��j��0�����܂�
        }
    }
}

