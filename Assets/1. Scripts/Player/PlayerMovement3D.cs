using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    [Header("Info")]
    private float speed = 5.0f;     //�̵� �ӵ�
    private float jumpForce = 2.5f; //���� ��
    private float gravity = -10f;   //�߷� ��(�ݵ�� ����������)

    [Header("State")]
    bool isRun; //�޸��� ���� ��

    private Vector3 moveDirection;  //�̵� ����

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isRun = Input.GetButton("Run"); //left shift�� ������ true ��ȯ
        
        //�� ��ġ�� �浹�� üũ�� �浹 ���̶�� true �ƴϸ� false
        if (characterController.isGrounded == false)
        {
            //�߷� ����
            moveDirection.y += gravity * Time.deltaTime;
        }
        //moveDirection�� �������� isRun�� �ǰ� speed�� �ӵ��� �̵�
        characterController.Move(moveDirection * (isRun ? speed = 8f : speed = 5f) * Time.deltaTime);
    }

    /// <summary>
    /// ���� ������ �Ű������� �޾ƿ��� ���� ������ moveDirection�� ����
    /// </summary>
    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void JumpTo()
    {
        //�� ��ġ�� �浹�� üũ�� �浹 ���̶�� true �ƴϸ� false
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}
