using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10;
    public float jumpHeight = 3f; //점프 높이 설정
    public bool isGrounded; //땅에 서있는지 체크하기 위한 bool값
    public LayerMask ground; //레이어 마스크 설정
    public float groundDistance = 0.2f;
    public float attackCulTime;
    public float attackCoolTime;

    private Animator picoChanAnim;
    private Rigidbody rb;
    Vector3 dir = Vector3.zero;
        
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.drag = 1;
        picoChanAnim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {      
        GroundCheck(); //땅 위에 서있는
        Move();
        Jump();
        Atttack();
        Turn();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * moveSpeed * Time.deltaTime);
    }

    void Move()
    {
        Vector3 moveVec = new Vector3(dir.x, 0, dir.z);
        float move = moveVec.magnitude;

        picoChanAnim.SetFloat("Move", move);
     
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        Vector3 Position = transform.position;

        Position.x += dir.x * Time.deltaTime * moveSpeed;
        Position.z += dir.z * Time.deltaTime * moveSpeed;

        transform.position = Position;

        if (dir != Vector3.zero)
        {
            transform.forward = dir;
        }
    }

    void Turn()
    {
        if(dir.x == 0 && dir.z == 0)
            return;

        Quaternion newRotation = Quaternion.LookRotation(dir);
        rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        //picoChanAnim.SetTrigger("Jump");
        if (Input.GetButtonDown("Jump") && isGrounded == true)	// IsGrounded가 true일 때만 점프할 수 있도록
        {
            Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            rb.AddForce(jumpVelocity, ForceMode.VelocityChange);
        }
    }

    void Atttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackCulTime += Time.deltaTime;
            if (attackCulTime > attackCoolTime)
            {
                attackCulTime = 0;
                Debug.Log("공격");
            }
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
