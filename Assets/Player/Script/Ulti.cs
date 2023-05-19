using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoodiesForFollowing
{

    public class Ulti : MonoBehaviour
    {
        public Transform firepoint;
        public GameObject Companion;
        public Rigidbody2D rb;
        public float FlySpeed = 5f;
        //���������� ��� �������� ��������� "������ �����"
        public static bool isThrown = false;
        private Vector2 startPosition;
        private Vector2 endPosition;
        private float targetX = 0f;



        private void Start()
        {
            startPosition = transform.position;
            endPosition = transform.position;
        }


        void Update()
        {

            if (Input.GetButtonDown("Fire1") && !isThrown)
            {
                //�������� ���������
                isThrown = true;
                startPosition = transform.position;
                endPosition = new Vector2(startPosition.x + targetX, startPosition.y);
            }
            //���� �������..
            if (isThrown)
            {
                //������ ��� ����������, �������������, �� ���� ����
                startPosition = transform.position;
                targetX = 5f;
                transform.position = Vector2.MoveTowards(startPosition, endPosition, FlySpeed * Time.deltaTime);

                //� ����� ��������� ����������� ����������...
                if (Vector2.Distance(transform.position, endPosition) < 0.5f)
                {
                    //�� ��������� "������ �����" �����������

                    isThrown = false;
                }
            }

        }

    }
}
