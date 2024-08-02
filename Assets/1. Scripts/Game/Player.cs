using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 50f;
    private Rigidbody rigid;

    bool isRun; //�޸��� ���� ��

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isRun = Input.GetButton("Run"); //left shift�� ������ true ��ȯ

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        Vector3 move = moveVec * speed * (isRun ? 2f : 1f) * Time.deltaTime;
        rigid.MovePosition(transform.position + move);

        transform.LookAt(transform.position + moveVec); //������ ���͸� ���ؼ� ȸ��������
    }
}
