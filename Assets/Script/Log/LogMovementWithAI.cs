using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform player; // ������ �� ������ ������
    private NavMeshAgent agent;
    public float chaseDistance = 10f; // ���������� ��� ������ �������������

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
        

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent �� ������. ���������, ��� ������ ����� ��������� NavMeshAgent.");
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player")!=null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else
        {
            return;
        }
        if (player != null && agent != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseDistance)
            {
                agent.SetDestination(player.position); // ��������� ������� ������ ��� ���� ��� �������������
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // ����������� ����� � ��������� ��� ������������ ���� �������������
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}
