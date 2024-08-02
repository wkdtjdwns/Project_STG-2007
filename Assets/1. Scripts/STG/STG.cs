using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class STG : MonoBehaviour
{
    [Header("STG Info")]
    public float speed = 5f;
    public float hp = 100;
    public float detectionRange = 5.0f; // �÷��̾ ������� �ִ� �Ÿ�
    public Transform target;

    [Header("Other")]
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        target = player.transform;
    }

    // STGTest Ŭ�������� Overriding�� �� �ֵ��� virtual Ű���带 ���� ���� �޼���� ������.
    public virtual void Move()
    {
        if (target != null)
        {
            // �÷��̾���� �Ÿ� ���
            float distance = Vector3.Distance(this.transform.position, target.position);

            // ���� �Ÿ� �̻� ������� ���� ���� ����ٴ�
            if (distance < detectionRange)
            {
                // Player�� ���� ���� ��� �� �̵�
                Vector3 direction = (target.position - transform.position).normalized;
                this.transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    public virtual void Hit(float damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            print("�ֱ� ��");
        }
    }
}
