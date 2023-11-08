using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StatsHero : MonoBehaviour
{

	
	[SerializeField] private TextMeshProUGUI healthHero;
	[SerializeField] private PlayerController playerController;
	[SerializeField] private TextMeshProUGUI healthHeroMain;
	[SerializeField] private Transform playerTransform;
	[SerializeField] private SpawnHero spawnHero;
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private Camera fightCamera;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Camera menuCamera;
	[SerializeField] private Canvas mainMenu;
	
	public GameObject enemy;
	[SerializeField] GameObject[] enemys;
	[SerializeField] GameObject[] clues;
	public float maxHealth = 100f;
    public float currentHealth = 100f;
	public float multiplayDeffense = 2f;
    //public static float attack = 15.5f;
    public float deffence = 0.5f;
	public bool isDefeat = false;


	void Start()
	{
		fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		menuCamera = GameObject.FindGameObjectWithTag("MenuCamera").GetComponent<Camera>();
		playerMovement = GetComponent<PlayerMovement>();
		playerController = GetComponent<PlayerController>();
		playerTransform = GetComponent<Transform>();
		enemys = GameObject.FindGameObjectsWithTag("Enemy");
		clues = GameObject.FindGameObjectsWithTag("podskazka");
		spawnHero = GameObject.FindGameObjectWithTag("SpawnHero").GetComponent<SpawnHero>();
		healthHero = GameObject.FindGameObjectWithTag("healthHero").GetComponent<TextMeshProUGUI>();
		healthHeroMain = GameObject.FindGameObjectWithTag("HealthMain").GetComponent<TextMeshProUGUI>();
		mainMenu = GameObject.FindGameObjectWithTag("MainMeny").GetComponent<Canvas>();
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
				isDefeat = true;
				healthHero.text = "HP: " + "0" + "/" + maxHealth;
				Debug.Log("���� ��������");
				mainCamera.enabled = false;
				fightCamera.enabled = false;
				menuCamera.enabled = true;
				spawnHero.ReturnHeroToSpawn();
				mainMenu.enabled = true;
				
				foreach (GameObject obj in enemys)
				{
					obj.SetActive(true);
				}
				foreach (GameObject obj in clues)
				{
					obj.SetActive(true);
				}
				playerController.isBattle = false;
			}
			
	}

	public void Deffence(float attack)
	{
		
			UpdateUI();
			if(currentHealth > 0f)
			{
				currentHealth = currentHealth - attack * deffence*multiplayDeffense;
				UpdateUI();
			}
			else if (currentHealth <= 0f)
			{
				healthHero.text = "HP: " + "0" + "/" + maxHealth;
				Debug.Log("���� ��������");
				mainCamera.enabled = false;
				fightCamera.enabled = false;
				menuCamera.enabled = true;
				spawnHero.ReturnHeroToSpawn();
				// enemy.gameObject.SetActive(false);
				playerController.isBattle = false;
			}
			else
			{
				UpdateUI();
			}
	}

	void UpdateUI()
	{
		currentHealth = Mathf.Min(currentHealth, maxHealth); // ������������ ����������� ���������� ������������ ������ ���������
		healthHero.text = "HP: " + currentHealth + "/" + maxHealth;
		healthHeroMain.text = "HP: " + currentHealth + "/" + maxHealth;
	}
}
