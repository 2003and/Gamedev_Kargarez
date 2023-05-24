using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{

    public float speed;
    private Vector2 direction;
    private Rigidbody2D rb;
    private int hp = 6;
    Animator animator;

    public float HP = 6;
    private bool isInvincible = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        animator.SetBool("Running", Math.Abs(direction.x) + Math.Abs(direction.y) > 0);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealPotion"))
        {
            HP = 6;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DmgIncrease"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DmgDecrease"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Enemy") && !isInvincible)
        {
            if (!isInvincible)
            {
                HP -= 1;
                isInvincible = true;
                Invoke("DisableInvincibility", 1.5f); // Выключение бессмертия через 1.5 секунды
            }
        }
    }

    void DisableInvincibility()
    {
        isInvincible = false;
    }
}
