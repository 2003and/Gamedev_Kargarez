using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ulti : MonoBehaviour
{

    public Rigidbody2D rb;

    public float speedOfThrow = 10f;
    //���������� ��� �������� ��������� "������ �����"
    private bool isThrown = false;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float targetX = 0f;
    private float targetY = 0f;


    private void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position;
    }

    
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //�������� ���������
            isThrown = true;
            targetX = 3f;
            endPosition = new Vector2(startPosition.x + targetX, startPosition.y);
        }
        //���� �������..
        if (isThrown)
        {
            //������ ��� ����������, �������������, �� ���� ����
            startPosition = transform.position;
            transform.position = Vector2.MoveTowards(startPosition, endPosition, speedOfThrow * Time.deltaTime);

            //� ����� ��������� ����������� ����������...
            if (Vector2.Distance(transform.position, endPosition) < 0.5f)
            {
                //�� ��������� "������ �����" �����������
                isThrown = false;
            }
        }
          

    }

}
