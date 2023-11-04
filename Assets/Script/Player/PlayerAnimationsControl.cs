using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsControl : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float movementThreshold = 0.1f; // ����� ��������

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // ����������� ����� �������� ��������
        float totalMovement = Mathf.Abs(moveX) + Mathf.Abs(moveY);

        if (totalMovement > movementThreshold)
        {
            // ����������� ����������� �������� �� �����������
            if (Mathf.Abs(moveX) > 0.01f)
            {
                if (moveX < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (moveX > 0)
                {
                    spriteRenderer.flipX = false;
                }
            }

            // ����������� ����������� �������� �� ���������
            if (Mathf.Abs(moveY) > 0.01f)
            {
                if (moveY > 0)
                {
                    animator.SetBool("MovingUp", true);
                    animator.SetBool("MovingDown", false);
                }
                else if (moveY < 0)
                {
                    animator.SetBool("MovingUp", false);
                    animator.SetBool("MovingDown", true);
                }
            }
            else
            {
                animator.SetBool("MovingUp", false);
                animator.SetBool("MovingDown", false);
            }

            // ��������� �������� ��� ��������
            animator.SetBool("Idle", false);
            //animator.SetFloat("MoveSide", moveX);
            animator.SetBool("MovingSide", true);
        }
        else
        {
            // ���� ��� ��������, ������������� �������� ��� ��������
            animator.SetBool("Idle", true);
            //animator.SetFloat("MoveSide", 0f);
            animator.SetBool("MovingSide", false);
            animator.SetBool("MovingUp", false);
            animator.SetBool("MovingDown", false);
        }
    }
}
