using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
using NUnit.Framework;

public class Fight : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Camera fightCamera;
	[SerializeField] private PlayerMovement playerMovement;
	public float notCaptureTime = 1.5f;
	[SerializeField] private bool isCapture = false;
	[SerializeField] private Button button;
	[SerializeField] private Attack attackScript;
	[SerializeField] private NavMeshAgent enemyNavMeshAgent;
	[SerializeField] private Button run_btn;
	[SerializeField] private Rigidbody2D _rb_enemy;
	[SerializeField] private Rigidbody2D player_rb;
	[SerializeField] private GameObject player;
	[SerializeField] private EnemyChase enemyMovement;
	[SerializeField] private PlayerController playerController; 
	[SerializeField] private StatsHero statsHero; 
	[SerializeField] private StatsEnemy statsEnemy; 
	// Start method - Initialization can be done here
	void Start()
	{
		run_btn = GameObject.FindGameObjectWithTag("RunButton").GetComponent<Button>();
		player_rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
		fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		button = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Button>();
		attackScript = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Attack>();
		enemyNavMeshAgent = GetComponent<NavMeshAgent>();
		enemyMovement = GetComponent<EnemyChase>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		statsHero = GameObject.FindGameObjectWithTag("Player").GetComponent<StatsHero>();
		statsEnemy = GetComponent<StatsEnemy>();
		_rb_enemy = GetComponent<Rigidbody2D>();
		run_btn.onClick.AddListener(RunFromEnemy);
	}
	

	// Update method - Update logic goes here
	void Update()
	{

	}

	public void RunFromEnemy()
	{
		_rb_enemy.constraints = RigidbodyConstraints2D.None;
		_rb_enemy.constraints = RigidbodyConstraints2D.FreezeRotation;

		player_rb.constraints = RigidbodyConstraints2D.None;
		player_rb.constraints = RigidbodyConstraints2D.FreezeRotation;

		playerMovement.enabled=true;
		enemyNavMeshAgent.enabled = true;
		enemyMovement.enabled = true;
		playerController.isBattle = false;
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (!isCapture)
			{
				
				statsEnemy.UpdateUI();
				CapturePlayer();
			}
			else
			{
				
				
				// If player is already captured, initiate the capture coroutine
				StartCoroutine(ReleasePlayerAfterDelay());
				isCapture = false;
			}
		}
	}

	void CapturePlayer()
	{
		// Capture the player immediately
		playerController.isBattle = true;
		enemyMovement.enabled = false;
		player_rb.constraints = RigidbodyConstraints2D.FreezePosition;
		player_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		enemyNavMeshAgent.enabled = false;
		_rb_enemy.constraints = RigidbodyConstraints2D.FreezePosition;
		_rb_enemy.constraints = RigidbodyConstraints2D.FreezeRotation;
		playerMovement.enabled = false;


		attackScript.enemy = gameObject;
		statsHero.enemy = gameObject;
		attackScript.statsEnemy = statsEnemy;
		attackScript.statsHero = statsHero;
		attackScript.player = player;


		Debug.Log("Enemy encountered");
		mainCamera.enabled = false;
		fightCamera.enabled = true;
		playerMovement.enabled = false;
		isCapture = true;
	}

	IEnumerator ReleasePlayerAfterDelay()
	{
		yield return new WaitForSeconds(notCaptureTime);
		CapturePlayer(); // After the delay, capture the player again
	}




}
