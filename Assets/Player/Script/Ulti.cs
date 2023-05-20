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
        public float FlySpeed = 1f;
        //���������� ��� �������� ��������� "������ �����"
        public static bool isThrown = false;
        private Vector2 startPosition;
        private Vector2 endPosition;
        private float targetX = 0f;
        Animator animator;
        public int CDownDefaultTicks=50;
        public static int CDown;
        private Vector2 mousePos;
        public Camera cam;
        private GameObject player;
        private Vector2 DeltaPos;
        
        private void Start()
        {
            startPosition = transform.position;
            endPosition = transform.position;   
            animator = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {

            if ((Input.GetButtonDown("Fire1")) & (CDown == 0))
            {
                //�������� ���������
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

                isThrown = true;
                CDown = CDownDefaultTicks;
                DeltaPos.x = mousePos.x-player.transform.position.x;
                DeltaPos.y = mousePos.y-player.transform.position.y;
                endPosition = Vector2.Scale(new Vector2(startPosition.x + DeltaPos.x, startPosition.y + DeltaPos.y).normalized, new Vector2(3,3));
                Debug.Log(endPosition.x);
                Debug.Log(endPosition.y);
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
            if ((isThrown==false) & (CDown>0))
                CDown -= 1;
            animator.SetBool("isFlying", isThrown);
            // Debug.Log(CDown);

        }

    }
}
