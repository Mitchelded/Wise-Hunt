using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StatsHero : MonoBehaviour
{

	
	[SerializeField] private TextMeshProUGUI healthHero;
	[SerializeField] private PlayerController playerController;
	// [SerializeField] private PlayerMovement playerMovement;
	// [SerializeField] private Camera fightCamera;
	// [SerializeField] private Camera mainCamera;
	
	 public GameObject enemy;

	public float maxHealth = 100f;
    public float currentHealth = 100f;
    //public static float attack = 15.5f;
    public float deffence = 0.5f;


	void Start()
	{
		// fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
		// mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		// playerMovement = GetComponent<PlayerMovement>();
		playerController = GetComponent<PlayerController>();
		healthHero = GameObject.FindGameObjectWithTag("healthHero").GetComponent<TextMeshProUGUI>();
		
	}

	public void TakeHit(float attack)
	{
		if (currentHealth > 0f)
		{
			currentHealth = currentHealth - attack * deffence;
			
			if (currentHealth <= 0f)
			{
				healthHero.text = "HP: " + "0" + "/" + maxHealth;
				Debug.Log("���� ��������");
				// mainCamera.enabled = true;
				// fightCamera.enabled = false;
				// playerMovement.enabled = true;
				// enemy.gameObject.SetActive(false);
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
		currentHealth = Mathf.Min(currentHealth, maxHealth); // ������������ ����������� ���������� ������������ ������ ���������
		healthHero.text = "HP: " + currentHealth + "/" + maxHealth;
	}
}
