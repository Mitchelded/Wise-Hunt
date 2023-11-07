using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Attack : MonoBehaviour
{

	public GameObject player;
	public TextMeshProUGUI healthEnemy;
	public GameObject enemy;
	public GameObject fightCamera;
	public GameObject mainCamera;

	// Start is called before the first frame update
	void Start()
	{
		Button attack_btn = GetComponent<Button>();

		attack_btn.onClick.AddListener(AttackToEnemy);
	}

	public void AttackToEnemy()
	{
		if (StatsEnemy.currentHealth > 0)
		{
			StatsEnemy.currentHealth = StatsEnemy.currentHealth - StatsHero.attack * StatsEnemy.deffence;
			Debug.Log(StatsEnemy.currentHealth);
			if (StatsEnemy.currentHealth <= 0)
			{
				healthEnemy.text = "HP: " + "0" + "/" + StatsEnemy.maxHealth;
				Debug.Log("Враг проиграл");
				mainCamera.gameObject.SetActive(true);
				fightCamera.gameObject.SetActive(false);
				player.gameObject.SetActive(true);
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
		StatsEnemy.currentHealth = Mathf.Min(StatsEnemy.currentHealth, StatsEnemy.maxHealth); // Ограничиваем фактическое количество максимальным числом подсказок
		healthEnemy.text = "HP: " + StatsEnemy.currentHealth + "/" + StatsEnemy.maxHealth;
	}
}
