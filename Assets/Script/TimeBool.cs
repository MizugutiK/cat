using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBool : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)�@ //�@�g���K�[�ɓ��������ꍇ
    {
        if (other.gameObject.tag == "Player")�@�@�@ //�@�������������I�u�W�F�N�g��Tag���hPlayer�h�Ȃ�
        {
            //�@GoalTrigger�ƌ������O�̃I�u�W�F�N�g�������āA�����ɂ���startTime��false�ɂ��܂�
            //GameObject.Find("GoalTrigger").GetComponent<CountDown>().startTime = false;
            //�@GoalTrigger�ƌ������O�̃I�u�W�F�N�g�������āA�����ɂ���countDown��15�𑫂��܂�            �@
            //GameObject.Find("GoalTrigger").GetComponent<CountDown>().countDown += 15.00f;
        }
    }
}
