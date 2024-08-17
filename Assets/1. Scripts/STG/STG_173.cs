using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_173 : STG
{
    public Light spotlight;  // ���Ͱ� ������ ��

    private bool isInLight = false;

    void Update()
    {
        CheckIfInLight();

        if (!isInLight)
        {
            Move();
        }
    }

    /// <summary>
    /// ���Ͱ� ���� ���� �ȿ� �ִ��� Ȯ���ϴ� �Լ�
    /// </summary>
    void CheckIfInLight()
    {
        // ���Ϳ� �� ������ ���� ���͸� ���
        Vector3 directionToMonster = transform.position - spotlight.transform.position;

        // ���� ����� ���� ������ ������ ���
        float angle = Vector3.Angle(spotlight.transform.forward, directionToMonster);

        // ���� ������ ���� ���� ���Ͱ� �ִ��� Ȯ��
        // - ���� ���� (spotAngle)�� ���ݺ��� �۰�
        // - ���� ���� (range) ���� ���� ���
        if (angle < spotlight.spotAngle / 2 && directionToMonster.magnitude < spotlight.range)
        {
            // ���Ͱ� �� �ȿ� ����
            isInLight = true;
        }
        else
        {
            // ���Ͱ� �� �ۿ� ����
            isInLight = false;
        }
    }
}
