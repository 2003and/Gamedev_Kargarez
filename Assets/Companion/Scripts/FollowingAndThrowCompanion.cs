using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoodiesForFollowing;

public class FollowingAndThrowCompanion : MonoBehaviour
{
    //private bool isCompanionThrown = false;
    //public float CooldownTime = 5f;
    public float speedOfFoll = 5f;                   //�������� �������������
    //public float speedOfThrow = 10f;
    public Rigidbody2D rb;
    Transform target;


    private Transform startPosition;
    private Transform endPosition;
    private Transform targetToThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    isCompanionThrown = true;
        //    Vector2 startPosition = transform.position;
        //    Vector2 endPosition = new Vector2(startPosition.x + 7, startPosition.y);
        //   float distance = Vector2.Distance(startPosition, endPosition);
        //    float timeOfThrow = distance / speedOfThrow;
        //
        //    Vector2 direction = (endPosition - startPosition).normalized;
        //   rb.velocity = new Vector2(distance, direction.y);

       // }
        //��� ��� ���� �� �������� isThrown ��������, ����� �� �� ����� �� �������, ���� ������
        //����� ������� ��� � ����� �����, ���� ��� ������ ��������� �� ����� isThrown == false
        //� ����� ������� ��������� ����������� �����, � ������� ����� ������ ���������� ���������
        //���� ������, ��, ���� ��� �����, � ���� �� �������� isThrown
        //� ��� ��� ���� ����� ����� ���������, �� � ��� ���������� ����� ����� ���������� ��������,
        //� �������� �� � ��������
        //��� ��� ���-��
        if (Ulti.isThrown == false)
        //{
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedOfFoll * Time.deltaTime);
        //}
    }
}
