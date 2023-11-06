using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI hintText; // ������ �� TextMeshPro ������ ��� ����������� ���������� ���������
    private int hintsCollected = 0; // ����������� ���������� ��������� ���������
    private const int maxHints = 10; // ������������ ���������� ���������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("podskazka") && hintsCollected < maxHints)
        {
            hintsCollected++;
            UpdateUI();
            other.gameObject.SetActive(false); // ��������� ���������
            Debug.Log("��������� ���� ���������");
        }
    }

    void UpdateUI()
    {
        hintsCollected = Mathf.Min(hintsCollected, maxHints); // ������������ ����������� ���������� ������������ ������ ���������
        hintText.text = "Podskazok: " + hintsCollected + "/" + maxHints;
    }
}
