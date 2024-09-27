using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera; // Посиланя на головну камеру

    public float maxSpeed = 10f; // Максимальна швидкість гравця
    public float forceTime = 1f; // Час дії інерції
    public float forceMultiplier = 100f; // Множник сили

    private Rigidbody rb; // Посилання на фізичний компонент

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Отримуємо позицію миші в світових координатах
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            //Визначаємо напрямок від слимака до точки курсору
            Vector3 direction = (targetPosition - transform.position).normalized;
            direction.y = 0;

            // Рухаємо персонажа при натиску ЛКМ (Ліва Кнопка Миші)
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(direction * forceMultiplier
                    * Time.deltaTime, ForceMode.Acceleration);
                // Обмежуємо максимальну швидкість
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            7,
            transform.position.z - 1);
    }
}
