using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static int height = 20;
    public static int width = 10;
    public float moveSpeed = 15f;    //이동 속도
    public float jumpSpeed = 600f;
    public bool isGrounded = false;
    public int jumpCount = 2; //점프횟수    2를 3으로 바꾸면 3단 점프
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //컴포넌트를 불러옴
        jumpCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;    //Ground에 닿으면 isGround는 true    
            jumpCount = 2;          //Ground에 닿으면 점프횟수가 2로 초기화됨
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))   //입력키가 위화살표면 실행함
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * jumpSpeed); //위방향으로 올라가게함
                    jumpCount--;    //점프할때 마다 점프횟수 감소
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) )    //왼쪽화살표 입력시 실행함
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))    //오른쪽화살표 입력시 실행함
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
       }
    }
}
