using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private bool facingRight = true; // ��� ������������ ����������� �����

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent <NavMeshAgent>();

        // ��������� ��������� �������� ������� ���������� � ���������
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsMovingUp", false);
        animator.SetBool("IsMovingDown", false);
        animator.SetBool("IsIdle", true);
    }

    void Update()
    {
        if (navMeshAgent.velocity.magnitude > 0)
        {
            // ���� ��������
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsIdle", false);

            // ���������� ����������� �������� � ������ flipX
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
            // ���� ����� �� �����
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", true);
        }

        // �������� ����������� �������� ����� �� ��� Y
        if (navMeshAgent.velocity.normalized.y > 0.1f)
        {
            // �������� �����
            animator.SetBool("IsMovingUp", true);
            animator.SetBool("IsMovingDown", false);
            animator.SetBool("IsWalking", false);
        }
        else if (navMeshAgent.velocity.normalized.y < -0.1f)
        {
            // �������� ����
            animator.SetBool("IsMovingUp", false);
            animator.SetBool("IsMovingDown", true);
            animator.SetBool("IsWalking", false);
        }
        else
        {
            // ���� �� �������� �� ���������
            animator.SetBool("IsMovingUp", false);
            animator.SetBool("IsMovingDown", false);
            animator.SetBool("IsWalking", true);
        }
    }

    // ����� ��� ��������� ���� �����
    void Flip()
    {
        facingRight = !facingRight;

        // �������� ������� �����
        Vector3 scale = transform.localScale;
        // ����������� ������� �� ��� X
        scale.x *= -1;
        // ��������� ����� �������
        transform.localScale = scale;
    }
}
