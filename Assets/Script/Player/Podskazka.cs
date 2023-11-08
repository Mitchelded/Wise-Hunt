using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public TextMeshProUGUI hintText; // Ссылка на TextMeshPro объект для отображения количества подсказок
	[SerializeField] private int hintsCollected = 0; // Фактическое количество собранных подсказок
	[SerializeField] private const int maxHints = 10; // Максимальное количество подсказок
	[SerializeField] private bool isCollecting = false;
	public float collectionTime = 1.5f;
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private PlayerAnimationsControl playerAnimationsControl;
	[SerializeField] private Rigidbody2D player_rb;
	public Animator animator;
	[SerializeField] private PlayerController playerController;
	[SerializeField] private GameObject enemy;
	public bool isBattle = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("podskazka") && hintsCollected < maxHints)
		{
			isCollecting = true;
			StartCoroutine(CollectHit(other.gameObject));

		}
	}

	void Start()
	{
		playerMovement = GetComponent<PlayerMovement>();
		playerAnimationsControl = GetComponent<PlayerAnimationsControl>();
		player_rb = GetComponent<Rigidbody2D>();
		playerController = GetComponent<PlayerController>();


	}

	void Update()
	{

		if (isCollecting && !isBattle)
		{

			playerMovement.enabled = false;
			animator.SetBool("Idle", true);
			animator.SetBool("MovingUp", false);
			animator.SetBool("MovingDown", false);
			animator.SetBool("MovingSide", false);
			playerAnimationsControl.enabled = false;
			player_rb.constraints = RigidbodyConstraints2D.FreezePosition;
		}
		else if (!isCollecting && !isBattle)
		{

			playerMovement.enabled = true;
			playerAnimationsControl.enabled = true;
			player_rb.constraints = RigidbodyConstraints2D.None;
			player_rb.constraints = RigidbodyConstraints2D.FreezeRotation;


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
		hintText.text = "Clue: " + hintsCollected + "/" + maxHints;
	}
}
