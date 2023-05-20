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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();
        animator.SetBool("Running", Math.Abs(direction.x)+Math.Abs(direction.y)>0);
    }

    void takeDamage()
    {
        hp -= 1;
        animator.SetBool("isHit", true);
        if (hp == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }


}
