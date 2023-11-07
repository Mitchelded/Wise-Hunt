using System.Collections;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject fightCamera;
    [SerializeField] private GameObject player;
    public float notCaptureTime = 1.5f;
    [SerializeField] private bool isCapture = false;
    public static GameObject enemyInstance;


    // Start method - Initialization can be done here
    void Start()
    {
        fightCamera = GameObject.FindGameObjectWithTag("FightCamera");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
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
        enemyInstance = gameObject;
        mainCamera.SetActive(false);
        fightCamera.SetActive(true);
        player.SetActive(false);
        gameObject.SetActive(false);
        isCapture = true;
    }

    IEnumerator ReleasePlayerAfterDelay()
    {
        yield return new WaitForSeconds(notCaptureTime);
        CapturePlayer(); // After the delay, capture the player again
    }



}
