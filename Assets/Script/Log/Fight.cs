using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

	public GameObject mainCamera;
	public GameObject fightCamera;
	public GameObject player;
	public float notCaptureTime = 100.5f;
	private bool isCapture = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (!isCapture)
			{
				Debug.Log("Враг соприкоснулся");
				mainCamera.gameObject.SetActive(false); // Отключаем подсказку
				fightCamera.gameObject.SetActive(true);
				player.gameObject.SetActive(false);
				gameObject.SetActive(false);
				isCapture=true;
			}
			else
			{
				StartCoroutine(CaptureHero(other.gameObject));
			}
			
		}
	}

	IEnumerator CaptureHero(GameObject hintObject)
	{
		yield return new WaitForSeconds(notCaptureTime);
		Debug.Log("Враг соприкоснулся");
		mainCamera.gameObject.SetActive(false); // Отключаем подсказку
		fightCamera.gameObject.SetActive(true);
		player.gameObject.SetActive(false);
		gameObject.SetActive(false);
		isCapture = true;
	}
	// Update is called once per frame
	void Update()
	{

	}
}
