using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StatsEnemy : MonoBehaviour
{
	public float maxHealth = 100f;
	public float currentHealth = 100f;
	//public static float attack = 15.5f;
	public float deffence = 0.5f;

	[SerializeField] private PlayerMovement player;
	[SerializeField] private TextMeshProUGUI healthEnemy;
	
	//public GameObject enemy;
	[SerializeField] private Camera fightCamera;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private GameObject enemy;
	//[SerializeField] private EnemyChase enemy;
	//[SerializeField] private EnemyChase enemyControl;



	void Start()
	{
		fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		healthEnemy = GameObject.FindGameObjectWithTag("healthEnemy").GetComponent<TextMeshProUGUI>();
		
		enemy = gameObject;
	}

	public void TakeHit(float attack)
	{
		if (currentHealth > 0f)
		{
			currentHealth = currentHealth - attack * deffence;
			Debug.Log(currentHealth);
			if (currentHealth <= 0f)
			{
				healthEnemy.text = "HP: " + "0" + "/" + maxHealth;
				Debug.Log("Враг проиграл");
				mainCamera.enabled = true;
				fightCamera.enabled = false;
				player.enabled = true;
				enemy.gameObject.SetActive(false);
			}
			else
			{
				UpdateUI();
			}


		}
	}

	void UpdateUI()
	{
		currentHealth = Mathf.Min(currentHealth, maxHealth); // Ограничиваем фактическое количество максимальным числом подсказок
		healthEnemy.text = "HP: " + currentHealth + "/" + maxHealth;
	}

}
