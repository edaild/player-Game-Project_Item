using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerscipt player = other.GetComponent<playerscipt>(); //PlayerBall�� ��ũ��Ʈ ������Ʈ ��������
            player.itemCount++; //������ ī��Ʈ + 1
            print("�������� ���Խ��ϴ�.");
            gameObject.SetActive(false); //������Ʈ ��Ȱ��ȭ
        }

    }
}


