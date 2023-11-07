using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private bool facingRight = true; // Для отслеживания направления врага

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent <NavMeshAgent>();

        // Установка начальных значений булевых переменных в аниматоре
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsMovingUp", false);
        animator.SetBool("IsMovingDown", false);
        animator.SetBool("IsIdle", true);
    }

    void Update()
    {
        if (navMeshAgent.velocity.magnitude > 0)
        {
            // Враг движется
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsIdle", false);

            // Определяем направление движения и меняем flipX
            Vector3 direction = navMeshAgent.desiredVelocity.normalized;
            if (direction.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            // Враг стоит на месте
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", true);
        }

        // Проверка направления движения врага по оси Y
        if (navMeshAgent.velocity.normalized.y > 0.1f)
        {
            // Движение вверх
            animator.SetBool("IsMovingUp", true);
            animator.SetBool("IsMovingDown", false);
            animator.SetBool("IsWalking", false);
        }
        else if (navMeshAgent.velocity.normalized.y < -0.1f)
        {
            // Движение вниз
            animator.SetBool("IsMovingUp", false);
            animator.SetBool("IsMovingDown", true);
            animator.SetBool("IsWalking", false);
        }
        else
        {
            // Враг не движется по вертикали
            animator.SetBool("IsMovingUp", false);
            animator.SetBool("IsMovingDown", false);
            animator.SetBool("IsWalking", true);
        }
    }

    // Метод для отражения вида врага
    void Flip()
    {
        facingRight = !facingRight;

        // Получаем масштаб врага
        Vector3 scale = transform.localScale;
        // Инвертируем масштаб по оси X
        scale.x *= -1;
        // Применяем новый масштаб
        transform.localScale = scale;
    }
}
