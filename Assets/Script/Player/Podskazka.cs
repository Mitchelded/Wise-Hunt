using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI hintText; // ������ �� TextMeshPro ������ ��� ����������� ���������� ���������
    private int hintsCollected = 0; // ����������� ���������� ��������� ���������
    private const int maxHints = 10; // ������������ ���������� ���������
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
		hintObject.gameObject.SetActive(false); // ��������� ���������
		Debug.Log("��������� ���� ���������");
		isCollecting = false;
	}

    void UpdateUI()
    {
        hintsCollected = Mathf.Min(hintsCollected, maxHints); // ������������ ����������� ���������� ������������ ������ ���������
        hintText.text = "Podskazok: " + hintsCollected + "/" + maxHints;
    }
}
