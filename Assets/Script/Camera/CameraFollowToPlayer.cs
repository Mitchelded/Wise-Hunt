using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollowToPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public float smoothSpeed = 0.125f; // ��������� ���������� ������
    public Vector3 offset; // ������ ������ �� ����



    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // ��������� ��������� ������ � ������������ � �����
        transform.LookAt(player);
    }
}
