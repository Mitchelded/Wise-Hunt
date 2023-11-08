using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StatsEnemy : MonoBehaviour
{
	public float maxHealth = 100f;
	public float currentHealth = 100f;
	
	public float deffence = 0.5f;
	[SerializeField] private PlayerController playerController;
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private TextMeshProUGUI healthEnemy;
	
	
	[SerializeField] private Camera fightCamera;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private GameObject enemy;
	



	void Start()
	{
		fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
				playerMovement.enabled = true;
				enemy.gameObject.SetActive(false);
				playerController.isBattle = false;
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
