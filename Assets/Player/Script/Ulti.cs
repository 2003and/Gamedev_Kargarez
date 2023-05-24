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
        //Переменная для фиксации состояния "Кастую ульту"
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

            if (Input.GetButtonDown("Fire1") && !isThrown)
            {
                //Начинает кастовать
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

                isThrown = true;
                startPosition = transform.position;
                endPosition = new Vector2(startPosition.x + targetX, startPosition.y);
            }
            //Пока кастует..
            if (isThrown)
            {
                //Делает все вычисления, передвигается, всё чики пуки
                startPosition = transform.position;
                targetX = 5f;
                transform.position = Vector2.MoveTowards(startPosition, endPosition, FlySpeed * Time.deltaTime);

                //И когда дистанция сократилась достаточно...
                if (Vector2.Distance(transform.position, endPosition) < 0.5f)
                {
                    //То состояние "Кастую ульту" выключается

                    isThrown = false;
                }
            }

        }

    }
}
