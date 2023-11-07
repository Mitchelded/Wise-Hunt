using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

	private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
		player = GetComponent<GameObject>();
		StatsHero.currentHealth = StatsHero.maxHealth - StatsEnemy.attack * StatsHero.deffence;

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
