using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject flash;

    public Transform turretBase; // ������ ���������
    public Transform turretBarrel; // ����� �����
    
    public float rotationSpeed = 5f; // �������� ���������
    public float tiltAngle = 30f; // ������������ ��� ������

    [Header("��������� �����")]

    public string turretName = "Turret"; // ����� �����
    public float turretDamage = 1f; // ����
    public float turretAttackSpeed = 1f; // ��������
    public float turretRange = 10f; // ����� �����
    public string turretDamageType = "Bullet"; // ����� ��������� �����
    public float baseBuildPrice = 100f; // ������ ���� �����
    public float baseUpgradePrice = 120f; // ֳ�� �������� �����

    private int upgradeCount = 1; // �������� �������
    private float currentUpgradePrice; // ������� ���� ��������

    private Transform enemy; // ֳ�� ������
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
            // �������� �������� �� ������ �� ���
            Vector3 barrelDirection = enemy.position - turretBarrel.position;

            // ���������� ��������� � �������� ���
            Quaternion rotation = Quaternion.LookRotation(barrelDirection);

            // �������� ��� ������
            float angle = Mathf.Clamp(rotation.eulerAngles.x, -tiltAngle, tiltAngle);

            // ��������� ��������� ��� ������ ������, ��������� ��������� �� �� Y
            Quaternion targetRotation = Quaternion.Euler(angle, rotation.eulerAngles.y, 0);

            // �������� ��� ��������� �� �� Y �� ������ �� ���������
            transform.rotation = Quaternion.Euler(
                transform.eulerAngles.x,
                turretBarrel.eulerAngles.y,
                transform.eulerAngles.z);

            // ����������� ��������� �� ������
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
