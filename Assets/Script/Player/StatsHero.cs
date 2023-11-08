using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StatsHero : MonoBehaviour
{

	[SerializeField] private PlayerMovement player;
	[SerializeField] private TextMeshProUGUI healthHero;
	
	[SerializeField] private Camera fightCamera;
	[SerializeField] private Camera mainCamera;
	
	 public GameObject enemy;

	public float maxHealth = 100f;
    public float currentHealth = 100f;
    //public static float attack = 15.5f;
    public float deffence = 0.5f;


	void Start()
	{
		fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		healthHero = GameObject.FindGameObjectWithTag("Player").GetComponent<TextMeshProUGUI>();
		
	}

	public void TakeHit(float attack)
	{
		if (currentHealth > 0)
		{
			currentHealth = currentHealth - attack * deffence;
			Debug.Log(currentHealth);
			if (currentHealth <= 0)
			{
				healthHero.text = "HP: " + "0" + "/" + maxHealth;
				Debug.Log("Враг проиграл");
				mainCamera.enabled = true;
				fightCamera.enabled = false;
				player.enabled = true;
				//enemy.enabled = false;
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
		healthHero.text = "HP: " + currentHealth + "/" + maxHealth;
	}
}
