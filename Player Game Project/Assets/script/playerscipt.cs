
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerscipt : MonoBehaviour
{
    public float speed;
    public GameObject[] weapons;
    public bool[] hasweapons;

    float hAxis;
    float vAxis;

    bool WDown;
    bool jump;

    bool iDown;
    bool isJump;

    Vector3 moveVec;

    Rigidbody rb; // �ɸ��͸� �����̱� ���� ����
    Animator anim;

    GameObject nearObject;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

    }
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Interation();
    }


    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        WDown = Input.GetButton("wolk");
        jump =  Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interation");


    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * (WDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWolk", WDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump() // ����
    {
        if (jump && !isJump) // ! ������ bool ���� ����
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            anim.SetBool("triggerJump", true);
            isJump = true;
        }
    }

    void Interation()
    {
        if(iDown && nearObject != null && !isJump)
        {
            if(nearObject.tag == "weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                int weaponIndex = item.value;
                hasweapons[weaponIndex] = true; // ������ ������ �����ͼ� �ش� ���� �Լ��� üũ
                print("���Ⱑ ���Խ��ϴ�.");
                Destroy(nearObject);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            anim.SetBool("triggerJump", false);
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
            nearObject = other.gameObject;

        Debug.Log(other.gameObject);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = null;
    }

}
