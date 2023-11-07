using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI hintText; // Ссылка на TextMeshPro объект для отображения количества подсказок
    private int hintsCollected = 0; // Фактическое количество собранных подсказок
    private const int maxHints = 10; // Максимальное количество подсказок
	private bool isCollecting = false;
	public float collectionTime = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("podskazka") && hintsCollected < maxHints)
        {
			isCollecting= true;
			StartCoroutine(CollectHit(other.gameObject));
        }
    }

	IEnumerator CollectHit(GameObject hintObject)
	{
		yield return new WaitForSeconds(collectionTime);
		hintsCollected++;
		UpdateUI();
		hintObject.gameObject.SetActive(false); // Отключаем подсказку
		Debug.Log("Подсказка была подобрана");
		isCollecting = false;
	}

    void UpdateUI()
    {
        hintsCollected = Mathf.Min(hintsCollected, maxHints); // Ограничиваем фактическое количество максимальным числом подсказок
        hintText.text = "Podskazok: " + hintsCollected + "/" + maxHints;
    }
}
