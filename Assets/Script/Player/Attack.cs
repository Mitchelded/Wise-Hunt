using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;

public class Attack : MonoBehaviour
{
	public float attackToEnemy = 15.5f;
	public float attackToHero = 15.5f;

	public GameObject enemy;
	public GameObject player;
	public PlayerController playerController;
	public StatsEnemy statsEnemy;
	public StatsHero statsHero;
	[SerializeField]private Button attack_btn;
	[SerializeField]private bool isPlayerTurn = true;

	[SerializeField]private int count = 0;

	// Start is called before the first frame update
	void Start()
	{
		attack_btn = GetComponent<Button>();
		// player  = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
		
		// statsEnemy = enemy.GetComponent<StatsEnemy>();
		
		
		// statsHero  = GameObject.FindGameObjectWithTag("Player").GetComponent<StatsHero>();

		// statsHero = player.GetComponent<StatsHero>();
		attack_btn.onClick.AddListener(AttackToEnemy);
		
		
	}

	private void Update() 
	{
		
		// playerController = player.GetComponent<PlayerController>();
		
		// // attack_btn.onClick.AddListener(AttackToEnemy);
		// if(isPlayerTurn && count==0 && playerController.isBattle)
		// {
		// 	count=1;
		// 	// attack_btn.onClick.AddListener(AttackToEnemy);
		// 	Debug.Log("Enemy take " + statsEnemy.currentHealth);
		// }
		// else if(!isPlayerTurn && count==1 && playerController.isBattle)
		// {
		// 	attack_btn.onClick.RemoveListener(AttackToEnemy);
		// 	statsHero.TakeHit(attack);
		// 	count=0;
		// 	Debug.Log("Player take " + statsHero.currentHealth);
		// }
	}


	public void AttackToEnemy()
	{
		
		statsEnemy.TakeHit(attackToEnemy);
		isPlayerTurn=false;
		attack_btn.interactable = false;
		Invoke("EnemyAtack", 1f);

	}

	public void EnemyAtack()
	{
		statsHero.TakeHit(attackToHero);
		isPlayerTurn=true;
		attack_btn.interactable = true;
	}


}


