using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    // private Vector3 originalScale;
    private SpriteRenderer sprite;
    // private Camera cam;
    void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        // originalScale = transform.localScale;
    }

    void Update()
    {
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosition = Input.mousePosition;
        Vector3 characterCenter = transform.position;
        Vector3 clickPosition = new Vector3(mousePosition.x, mousePosition.y, characterCenter.z);
        Debug.Log("Click Position: " + clickPosition);
        // GetComponent<Canvas>();

        if (mousePosition.x < Screen.width/2)
        {
            // gameObject.transform.localScale = new Vector3 (-originalScale.x,originalScale.y,originalScale.z );
            sprite.flipX = true;
        } else {
            // gameObject.transform.localScale = new Vector3 (originalScale.x,originalScale.y,originalScale.z);
            sprite.flipX = false;
        }
    }
}
