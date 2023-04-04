using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 3f; //���� ���� ����
    public bool isGrounded; //���� ���ִ��� üũ�ϱ� ���� bool��
    public LayerMask ground; //���̾� ����ũ ����
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
                Debug.Log("����");
            }
        }

        GroundCheck(); //�� ���� ���ִ�
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
        if (Input.GetButtonDown("Jump") && isGrounded == true)	// IsGrounded�� true�� ���� ������ �� �ֵ���
        {
            Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            rb.AddForce(jumpVelocity, ForceMode.VelocityChange);
        }
    }

    void GroundCheck()
    {
        RaycastHit hit;

        // �÷��̾��� ��ġ����, �Ʒ���������, groundDistance ��ŭ ray�� ����, ground ���̾ �ִ��� �˻�
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
