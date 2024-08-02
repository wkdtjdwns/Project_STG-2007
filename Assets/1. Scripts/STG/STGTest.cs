using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGTest : STG
{
    private void Awake()
    {
        
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
    public override void Move()
    {
        print("Move() �������̵�");
        base.Move(); // STG Ŭ������ �ִ� Move() �޼��� �ҷ�����
    }

    public override void Hit(float damage)
    {
        // �ǰ� �ִϸ��̼� �ֱ�
        print("���Ŀ�");
        base.Hit(damage); // STG Ŭ������ �ִ� Hit(float damage) �޼��� �ҷ�����
    }
}
