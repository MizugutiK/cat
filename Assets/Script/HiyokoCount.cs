using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiyokoCount : MonoBehaviour
{
    GameObject[] enemyObjects;
    int enemyNum;
    void Start()
    {
        enemyObjects = GameObject.FindGameObjectsWithTag("Hiyoko");
        enemyNum = enemyObjects.Length;
    }
}

