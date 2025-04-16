using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject flash;

    public Transform turretBase; // Кругла платформа
    public Transform turretBarrel; // Ствол турелі
    
    public float rotationSpeed = 5f; // Швидкість обертання
    public float tiltAngle = 30f; // Максимальний кут нахилу

    [Header("Параметри турелі")]

    public string turretName = "Turret"; // Назва турелі
    public float turretDamage = 1f; // Урон
    public float turretAttackSpeed = 1f; // Інтервал
    public float turretRange = 10f; // Радіус турелі
    public string turretDamageType = "Bullet"; // Спосіб нанесення урону
    public float baseBuildPrice = 100f; // Базова ціна турелі
    public float baseUpgradePrice = 120f; // Ціна апгрейду турелі

    private int upgradeCount = 1; // Поточний апгрейд
    private float currentUpgradePrice; // Поточна ціна апгрейду

    private Transform enemy; // Ціль ворога
    private EnemyAgent enemyAgent;
    private List<GameObject> enemiesInRange;
    private Vector3 direction;

    private bool reload = false;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();

    }
    public void SetUpgradePrice()
    {
        currentUpgradePrice = baseBuildPrice + baseUpgradePrice * upgradeCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        enemiesInRange.Remove(other.gameObject);
    }
    void Update()
    {
        enemiesInRange.RemoveAll(enemy => enemy == null);
        if (enemiesInRange.Count > 0)
        {
            enemy = enemiesInRange[0].transform;
        }
        if (enemy != null)
        {
            BarrelAndPlatformRotation();

            if (!reload)
            {
                Shoot();
                StartCoroutine(Reload());
            }
        }

        void BarrelAndPlatformRotation()
        {
            // Отримуємо напрямок від ствола до цілі
            Vector3 barrelDirection = enemy.position - turretBarrel.position;

            // Обчислюємо обертання в напрямку цілі
            Quaternion rotation = Quaternion.LookRotation(barrelDirection);

            // Обмежуємо кут нахилу
            float angle = Mathf.Clamp(rotation.eulerAngles.x, -tiltAngle, tiltAngle);

            // Створюємо обертання для нахилу ствола, зберігаючи обертання по осі Y
            Quaternion targetRotation = Quaternion.Euler(angle, rotation.eulerAngles.y, 0);

            // Передаємо кут обертання по осі Y від ствола до платформи
            transform.rotation = Quaternion.Euler(
                transform.eulerAngles.x,
                turretBarrel.eulerAngles.y,
                transform.eulerAngles.z);

            // Застосовуємо обертання до ствола
            turretBarrel.localRotation = targetRotation;
        }
    }
    void Shoot()
    {
        enemyAgent = enemy.gameObject.GetComponent<EnemyAgent>();

        direction = transform.forward;
        direction = direction.normalized;
        Instantiate(flash, spawnPoint.position, Quaternion.LookRotation(direction));

        if (enemy != null && enemyAgent.hitPoints.value > 1)
        {
            enemyAgent.hitPoints.value -= turretDamage;
        }
        else if (enemy != null && enemyAgent.hitPoints.value <= 1)
        {
            enemiesInRange.Remove(enemy.gameObject);
            Destroy(enemy.gameObject);
        }
    }
    IEnumerator Reload()
    {
        reload = true;
        yield return new WaitForSeconds(turretAttackSpeed);
        reload = false;
    }
}
