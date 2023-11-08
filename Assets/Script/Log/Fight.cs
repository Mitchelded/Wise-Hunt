using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;

public class Fight : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera fightCamera;
    [SerializeField] private PlayerMovement player;
    public float notCaptureTime = 1.5f;
    [SerializeField] private bool isCapture = false;
	public static GameObject enemyInstance;
	[SerializeField] private Button button;
	[SerializeField] private Attack attackScript;


	// Start method - Initialization can be done here
	void Start()
    {
        fightCamera = GameObject.FindGameObjectWithTag("FightCamera").GetComponent<Camera>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		button = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Button>();
		attackScript = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Attack>();

	}

    // Update method - Update logic goes here
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isCapture)
            {
				//enemyInstance = gameObject;

				attackScript.enemy = gameObject;
				attackScript.statsEnemy = GetComponent<StatsEnemy>();
				CapturePlayer();
            }
            else
            {
                // If player is already captured, initiate the capture coroutine
                StartCoroutine(ReleasePlayerAfterDelay());
                isCapture = false;
            }
        }
    }

    void CapturePlayer()
    {
        // Capture the player immediately

        Debug.Log("Enemy encountered");
		
		
		mainCamera.enabled=false;
        fightCamera.enabled = true;
        player.enabled = false;
		
        isCapture = true;
    }

    IEnumerator ReleasePlayerAfterDelay()
    {
        yield return new WaitForSeconds(notCaptureTime);
        CapturePlayer(); // After the delay, capture the player again
    }



}
