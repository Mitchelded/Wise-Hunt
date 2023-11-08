using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;

public class Attack : MonoBehaviour
{
	public float attack = 15.5f;
	//   [SerializeField] private PlayerMovement player;
	//public TextMeshProUGUI healthEnemy;
	//   //public GameObject enemy;
	//   [SerializeField] private Camera fightCamera;
	//   [SerializeField] private Camera mainCamera;
	//[SerializeField] private EnemyChase enemy;
	public GameObject enemy;
	public StatsEnemy statsEnemy;
	// Start is called before the first frame update
	void Start()
	{
		Button attack_btn = GetComponent<Button>();
		//fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
		//mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		//player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		//enemy = Fight.enemyInstance;
		
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
