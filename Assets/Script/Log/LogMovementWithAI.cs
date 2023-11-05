using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    private NavMeshAgent agent;
    public float chaseDistance = 10f; // Расстояние для начала преследования

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent не найден. Убедитесь, что объект имеет компонент NavMeshAgent.");
        }
    }

    void Update()
    {
        if (player != null && agent != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseDistance)
            {
                agent.SetDestination(player.position); // Установка позиции игрока как цели для преследования
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Отображение сферы в редакторе для визуализации зоны преследования
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}
