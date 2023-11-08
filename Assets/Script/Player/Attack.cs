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
	[SerializeField]private Button deffence_btn;
	[SerializeField]private Button run_btn;
	[SerializeField]private bool isPlayerTurn = true;
	[SerializeField] private TextMeshProUGUI healthEnemy;
	[SerializeField]private int count = 0;

	// Start is called before the first frame update
	void Start()
	{
		deffence_btn = GameObject.FindGameObjectWithTag("DeffenseButton").GetComponent<Button>();
		run_btn = GameObject.FindGameObjectWithTag("RunButton").GetComponent<Button>();
		attack_btn = GetComponent<Button>();
		// player  = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
		
		// statsEnemy = enemy.GetComponent<StatsEnemy>();
		
		
		// statsHero  = GameObject.FindGameObjectWithTag("Player").GetComponent<StatsHero>();

		// statsHero = player.GetComponent<StatsHero>();
		attack_btn.onClick.AddListener(AttackToEnemy);
		
		
	}

	private void Update() 
	{
		
		
	}


	public void AttackToEnemy()
	{
		if (playerController != null && statsEnemy != null)
    	{
			if(!playerController.pultIsPick)
			{
				statsEnemy.TakeHit(attackToEnemy);
			}
			else if(playerController.pultIsPick)
			{
				attackToEnemy = 999999f;
				statsEnemy.TakeHit(attackToEnemy);
			}
			
			isPlayerTurn=false;
			attack_btn.interactable = false;
			deffence_btn.interactable=false;
			run_btn.interactable = false;
			Invoke("EnemyAtack", 1f);
		}
		else
		{
			Debug.LogError("playerController or statsEnemy is not assigned!");
			// Perform additional error handling or assignment here.
		}
	}

	public void DeffenceFromEnemy()
	{
		statsHero.Deffence(attackToHero);
		isPlayerTurn=false;
		attack_btn.interactable = false;
		deffence_btn.interactable=false;
		run_btn.interactable = false;
		Invoke("EnemyAtack", 1f);
	}

	public void EnemyAtack()
	{
		statsHero.TakeHit(attackToHero);
		isPlayerTurn=true;
		attack_btn.interactable = true;
		deffence_btn.interactable=true;
		run_btn.interactable = true;
	}


}


