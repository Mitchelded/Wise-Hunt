using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollowToPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public float smoothSpeed = 0.125f; // Плавность следования камеры
    public Vector3 offset; // Отступ камеры от цели



    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Установка положения камеры в соответствии с целью
        transform.LookAt(player);
    }
}
