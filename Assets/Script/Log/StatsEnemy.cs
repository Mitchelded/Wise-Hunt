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
	public GameObject enemy;
	



	void Start()
	{
		fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		healthEnemy = GameObject.FindGameObjectWithTag("healthEnemy").GetComponent<TextMeshProUGUI>();
		enemy = gameObject;
		
	}

	void Update()
	{
		// UpdateUI();
	}

	public void TakeHit(float attack)
	{

		

			if(currentHealth - attack * deffence > 0 && playerController.isBattle)
			{
				currentHealth = currentHealth - attack * deffence;
				UpdateUI();
			}
			else if (currentHealth - attack * deffence <= 0f)
			{
				healthEnemy.text = "HP: " + "0" + "/" + maxHealth;
				Debug.Log("���� ��������");
				mainCamera.enabled = true;
				fightCamera.enabled = false;
				playerMovement.enabled = true;
				enemy.gameObject.SetActive(false);
				playerController.isBattle = false;
			}


	}

	public void UpdateUI()
	{
		currentHealth = Mathf.Min(currentHealth, maxHealth); // ������������ ����������� ���������� ������������ ������ ���������
		healthEnemy.text = "HP: " + currentHealth + "/" + maxHealth;
	}

}
