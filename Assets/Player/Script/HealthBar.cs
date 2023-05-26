using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float HP = 6;
    public Image[] hearts;
    public Sprite full;
    public Sprite half;
    public Sprite empty;
    private bool isInvincible = false;

    void FixedUpdate()
    {
        if (HP > 6) 
        { 
            HP = 6; 
        }

        if (HP == 6)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = full;
            hearts[2].sprite = full;
        }
        else if (HP == 5)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = full;
            hearts[2].sprite = half;
        }
        else if (HP == 4)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = full;
            hearts[2].sprite = empty;
        }
        else if (HP == 3)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = half;
            hearts[2].sprite = empty;
        }
        else if (HP == 2)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = empty;
            hearts[2].sprite = empty;
        }
        else if (HP == 1)
        {
            hearts[0].sprite = half;
            hearts[1].sprite = empty;
            hearts[2].sprite = empty;
        }
        else if (HP == 0)
        {
            hearts[0].sprite = empty;
            hearts[1].sprite = empty;
            hearts[2].sprite = empty;
        }
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
