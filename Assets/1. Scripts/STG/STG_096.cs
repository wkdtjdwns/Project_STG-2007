using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MoveDirection
{
    Forward,
    Back,
    Left,
    Right
};

public class STG_096 : STG
{
    [SerializeField] private MoveDirection moveType;

    private Vector3 direction;
    void Start()
    {
        // �ʱ� �̵� ���� ����
        switch (moveType)
        {
            case MoveDirection.Forward:
                direction = Vector3.forward;
                break;
            case MoveDirection.Back:
                direction = Vector3.back;
                break;
            case MoveDirection.Left:
                direction = Vector3.left;
                break;
            case MoveDirection.Right:
                direction = Vector3.right;
                break;
        }
    }
    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hit(10);
        }
    }

    // STG Ŭ������ Move() �޼��� �������̵�
    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public override void Hit(float damage)
    {
        // �ǰ� �ִϸ��̼� �ֱ�
        print("���Ŀ�");
        base.Hit(damage); // STG Ŭ������ �ִ� Hit(float damage) �޼��� �ҷ�����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            // ���� �ε����� 180�� ȸ��
            direction = -direction;
        }
    }
}
