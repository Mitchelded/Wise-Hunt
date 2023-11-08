using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;

public class Attack : MonoBehaviour
{
	public float attack = 15.5f;
	
	public GameObject enemy;
	public StatsEnemy statsEnemy;
	

	// Start is called before the first frame update
	void Start()
	{
		Button attack_btn = GetComponent<Button>();
		
		while (enemy = null)
		{
			statsEnemy = enemy.GetComponent<StatsEnemy>();
		}
		attack_btn.onClick.AddListener(AttackToEnemy);
	}


	public void AttackToEnemy()
	{
		statsEnemy.TakeHit(attack);

	}


}
