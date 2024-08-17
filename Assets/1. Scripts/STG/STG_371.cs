using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_371 : STG
{
    public Light spotlight;  // ���Ͱ� ������ ��
    public float attackThreshold = 5.0f;  // ���ݱ��� �ʿ��� �ð�

    private bool isInLight = false;
    private float timeInLight = 0f;//���� ���� ���ִ� �ð�

    void Update()
    {
        CheckIfInLight();

        if (isInLight)
        {
            // �� �ȿ� ���� �� �ð��� ����ϸ� ����
            timeInLight += Time.deltaTime;

            if (timeInLight >= attackThreshold)
            {
                Move(); // �� �ȿ� ���� ���� �̵�
            }
        }
        else
        {
            // �� �ۿ� ������ �ð� �ʱ�ȭ
            timeInLight = 0f;
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
