using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

	private GameObject player;


	// Start is called before the first frame update
	void Start()
	{

		player = GetComponent<GameObject>();

		StatsEnemy.currentHealth = StatsEnemy.maxHealth - StatsHero.attack * StatsEnemy.deffence;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
