using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;//���� ���������� ����
    [SerializeField] float Speed = 10f; // �������� �������
    [SerializeField] Animator Animator_road;
    private bool IsMove;// ���������� ��� �������� ��������� ������� ������
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();// ��������� ����������� ���� � ������
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)//��������� ������� 
        {
            IsMove = true;// ������� ������
        }
        else // ����� 
        {
            IsMove = false;// ������� �� ������
            Rigidbody2D.velocity = Vector2.zero; // �������  ��������� �������
        }
    }
    private void FixedUpdate()
    {
        if (IsMove)  // ���� ��������� ������� ������
        {
            // GetAxis  ���������� -1 ���� ������  ����� � 1 ���� ������ ������ � 0 ���� ������ �� ������
            Rigidbody2D.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * Speed); // ��������� ���� ������ ����������� ����
        }
        if ((int)Input.GetAxisRaw("Vertical") ==1)
        {
            if (Animator_road.speed < 3f)
            {
                Animator_road.speed += 0.01f;

            }
        }
        if ((int)Input.GetAxisRaw("Vertical") == -1)
        {
            if (Animator_road.speed > 0.5f)
            {
                Animator_road.speed -= 0.01f;

            }
        }
    }
}
