using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 3f; //점프 높이 설정
    public bool isGrounded; //땅에 서있는지 체크하기 위한 bool값
    public LayerMask ground; //레이어 마스크 설정
    public float groundDistance = 0.2f;

    public float attackCulTime;
    public float attackCoolTime;

    private Rigidbody rb;
    Vector3 dir = Vector3.zero;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackCulTime += Time.deltaTime;
            if(attackCulTime > attackCoolTime)
            {
                attackCulTime = 0;
                Debug.Log("공격");
            }
        }

        GroundCheck(); //땅 위에 서있는
        InputAndDir();
        Jump();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
    }

    void InputAndDir()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        if(dir != Vector3.zero)
        {
            transform.forward = dir;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)	// IsGrounded가 true일 때만 점프할 수 있도록
        {
            Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            rb.AddForce(jumpVelocity, ForceMode.VelocityChange);
        }
    }

    void GroundCheck()
    {
        RaycastHit hit;

        // 플레이어의 위치에서, 아래방향으로, groundDistance 만큼 ray를 쏴서, ground 레이어가 있는지 검사
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance, ground))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
