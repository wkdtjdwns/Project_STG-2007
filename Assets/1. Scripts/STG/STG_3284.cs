using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_3284 : STG
{
    private float attackTime;
    private bool isHit;

    private void Awake()
    {
        isHit = false;
        attackTime = 2.5f;

        detectionRange = 2.5f;
        target = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (target != null)
        {
            // �÷��̾���� �Ÿ� ���
            float distance = Vector3.Distance(this.transform.position, target.position);

            // ���� �Ÿ� �̻� ������� ���� ���� ������
            if (distance < detectionRange && !isHit)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        isHit = true;

        this.transform.position = target.position;
        print("�÷��̾� ����");
        //target.GetComponent<Player>().������ �Դ� �Լ�() (�ƹ�ư �÷��̾�� �������� ������ �Լ��� ��);

        yield return new WaitForSeconds(attackTime);

        isHit = false;
    }

    public override void Hit(float damage)
    {
        // �ǰ� �ִϸ��̼� �ֱ�
        print("�ƾ�");
        base.Hit(damage); // STG Ŭ������ �ִ� Hit(float damage) �޼��� �ҷ�����
    }
}
