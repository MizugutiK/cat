using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneDestory : MonoBehaviour
{
	public int life = 3;             // エネミーの体力を入れる変数を用意します

	private void OnCollisionEnter(Collision other)   // もし、何かと接触したら
	{
		if (other.gameObject.tag == "Bullet")   // その接触したオブジェクトのTagが”Bullet”ならば
		{
			life -= 1;           // 変数lifeから1引きます
			if (life <= 0)           // 変数lifeの値が0以下になったら
			{
				gameObject.SetActive(false);     // このオブジェクトを非表示にします
			}
		}
	}

}
