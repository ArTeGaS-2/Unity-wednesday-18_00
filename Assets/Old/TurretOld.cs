using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretOld : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject flash;

    public Transform turretBase;
    public Transform turretBarrel;

    public float rotationSpeed = 5f;
    public float tiltAngle = 30f;

    private Transform enemy;
    private List<GameObject> enemiesInRange;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();
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
    private void Update()
    {
        if(enemiesInRange.Count > 0)
        {
            enemy = enemiesInRange[0].transform;
        }
        if(enemy != null)
        {
            BarrelAndPlatformRotation();
        }
    }
    void BarrelAndPlatformRotation()
    {
        Vector3 barrelDirection = enemy.position - turretBarrel.position;
        Quaternion rotation = Quaternion.LookRotation(barrelDirection);
        float angle = Mathf.Clamp(rotation.eulerAngles.x, -tiltAngle, tiltAngle);
        Quaternion targetRotation = Quaternion.Euler(angle, rotation.eulerAngles.y, 0);

        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            turretBarrel.eulerAngles.y,
            transform.eulerAngles.z);

        turretBarrel.localRotation = targetRotation;
    }
}
