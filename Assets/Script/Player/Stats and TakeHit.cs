using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsandTakeHit : MonoBehaviour
{

	public float maxHealth = 100f;
	public float currentHealth = 100f;
	public float attack = 15.5f;
	public float deffence = 0.5f;

	public void TakeHit(float damage)
	{
		currentHealth -= damage;
	}

}
