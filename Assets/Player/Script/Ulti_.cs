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
        private Vector2 veryFirstStartPosition;
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

        // void OnCollisionEnter (GameObject other) {
        //     if (other.tag == "Enemy"){
        //         other.GetComponent<Karga_1>().TakeDamege(2);
        //     }
        //     isThrown = false;
        //     CDown=(int)(CDownDefaultTicks/2);
        // }

        void Update()
        {
            if (Input.GetButtonDown("Fire1") && !isThrown && CDown<=0)
            {
                Debug.Log("pisyapopa");
                //Начинает кастовать
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

                isThrown = true;
                startPosition = transform.position;
                veryFirstStartPosition = transform.position;

                endPosition = new Vector2(mousePos.x, mousePos.y);
            } else {
                CDown -= 1;
            }
            //Пока кастует..
            if (isThrown)
            {
                //Делает все вычисления, передвигается, всё чики пуки
                startPosition = transform.position;
                targetX = 5f;

                //И когда дистанция сократилась достаточно...
                transform.position = Vector2.MoveTowards(startPosition, endPosition, FlySpeed * Time.deltaTime);
                if ((Vector2.Distance(transform.position, endPosition) < 0.5f) || (Vector2.Distance(transform.position, veryFirstStartPosition) > 5f))
                {
                    //То состояние "Кастую ульту" выключается
                    CDown=CDownDefaultTicks;
                    isThrown = false;
                }

                // //И когда дистанция сократилась достаточно...
                // if ((Vector2.Distance(transform.position, endPosition) < 0.5f) || (Vector2.Distance(transform.position, veryFirstStartPosition) > 5f))
                // {
                //     transform.position = Vector2.MoveTowards(startPosition, endPosition, FlySpeed * Time.deltaTime);
                // } else {
                //     //То состояние "Кастую ульту" выключается
                //     CDown=CDownDefaultTicks;
                //     isThrown = false;
                // }
            }

        }

        void DamageKarga(){

        }

    }
}
