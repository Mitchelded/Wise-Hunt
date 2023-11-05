using UnityEngine;


public class MonsterController : MonoBehaviour
{
    public Transform player;
    public float speed = 15f;
    private float distance;
    private BoxCollider2D _boxCollider2D;
    public float distanceBetween = 0;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        Vector2 direction = player.position - transform.position;
        direction.Normalize();

        if (distance > distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Collision with: " + collision.collider.name); // Output the name of the collided object
        }
    }
}
