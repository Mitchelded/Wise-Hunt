using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI hintText; // Ссылка на TextMeshPro объект для отображения количества подсказок
    private int hintsCollected = 0; // Фактическое количество собранных подсказок
    private const int maxHints = 10; // Максимальное количество подсказок

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("podskazka") && hintsCollected < maxHints)
        {
            hintsCollected++;
            UpdateUI();
            other.gameObject.SetActive(false); // Отключаем подсказку
            Debug.Log("Подсказка была подобрана");
        }
    }

    void UpdateUI()
    {
        hintsCollected = Mathf.Min(hintsCollected, maxHints); // Ограничиваем фактическое количество максимальным числом подсказок
        hintText.text = "Podskazok: " + hintsCollected + "/" + maxHints;
    }
}
