using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;//Наше физическое тело
    [SerializeField] float Speed = 10f; // Скорость машинки
    [SerializeField] Animator Animator_road;
    private bool IsMove;// Переменная для хранения состояния нажатия клавиш
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();// Получение физического тела в начале
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)//Получение нажатия 
        {
            IsMove = true;// Клавиши нажаты
        }
        else // Иначе 
        {
            IsMove = false;// Клавиши не нажаты
            Rigidbody2D.velocity = Vector2.zero; // Убираем  ускорение машинки
        }
    }
    private void FixedUpdate()
    {
        if (IsMove)  // Если состояние клавиши нажаты
        {
            // GetAxis  возвращает -1 если нажата  влево и 1 если нажато вправо и 0 если ничего не нажато
            Rigidbody2D.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * Speed); // Добавляем силу нашему физическому телу
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
