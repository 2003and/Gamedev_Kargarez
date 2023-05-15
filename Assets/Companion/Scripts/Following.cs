using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{

    public float speed;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //��� ��� ���� �� �������� isThrown ��������, ����� �� �� ����� �� �������, ���� ������
        //����� ������� ��� � ����� �����, ���� ��� ������ ��������� �� ����� isThrown == false
        //� ����� ������� ��������� ����������� �����, � ������� ����� ������ ���������� ���������
        //���� ������, ��, ���� ��� �����, � ���� �� �������� isThrown
        //� ��� ��� ���� ����� ����� ���������, �� � ��� ���������� ����� ����� ���������� ��������,
        //� �������� �� � ��������
        //��� ��� ���-��
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
}
