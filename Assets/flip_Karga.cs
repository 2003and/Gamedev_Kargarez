using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip_Karga : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (mousePosition.x < Screen.width/2)
        {
            sprite.flipX = true;
        } else {
            sprite.flipX = false;
        }
    }
}
