using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoodiesForFollowing
{
<<<<<<< Updated upstream

    public Rigidbody2D rb;

    public float speedOfThrow = 10f;
    //���������� ��� �������� ��������� "������ �����"
    private bool isThrown = false;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float targetX = 0f;
    private float targetY = 0f;


    private void Start()
=======

    public class Ulti : MonoBehaviour
>>>>>>> Stashed changes
    {
        public Transform firepoint;
        public GameObject Companion;
        public Rigidbody2D rb;
        public float FlySpeed = 1f;
        //���������� ��� �������� ��������� "������ �����"
        public static bool isThrown = false;
        private Vector2 startPosition;
        private Vector2 endPosition;
        private float targetX = 0f;



        private void Start()
        {
<<<<<<< Updated upstream
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
=======
            startPosition = transform.position;
            endPosition = transform.position;
        }


        void Update()
        {

            if (Input.GetButtonDown("Fire1"))
            {
                //�������� ���������
                isThrown = true;
                endPosition = new Vector2(startPosition.x + targetX, startPosition.y);
            }
            //���� �������..
            if (isThrown)
            {
                //������ ��� ����������, �������������, �� ���� ����
                startPosition = transform.position;
                targetX = 3f;
                transform.position = Vector2.MoveTowards(startPosition, endPosition, FlySpeed * Time.deltaTime);

                //� ����� ��������� ����������� ����������...
                if (Vector2.Distance(transform.position, endPosition) < 0.5f)
                {
                    //�� ��������� "������ �����" �����������

                    isThrown = false;
                }
            }


>>>>>>> Stashed changes
        }

    }
}
