using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;�@�@�@//�@SceneManagement���p�����܂�

public class RePlay : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   // ���݂�Scene�����[�h����
    }

}
