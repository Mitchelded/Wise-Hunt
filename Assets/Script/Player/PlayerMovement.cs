using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    public float speed = 20f;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);

        movement.Normalize();

        // Применяем движение к Rigidbody2D
        _rb.velocity = movement * speed;
    }
}
