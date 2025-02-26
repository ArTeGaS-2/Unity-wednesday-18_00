using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWavesUPD : MonoBehaviour
{
    [Header("������� ������")]
    // ������ ������� ������, �� ������� ��������
    public List<GameObject> enemyPrefabs;

    [Header("������������ ������")]
    // �������� �� ������� (���� ���������� ������ ������� ����
    public float spawnWaveDelay = 15f;
    // �������� �� ������� ������� ������ �������� ����
    public float spawnEnemyDelay = 2f;
    // ����� ��� ������� ������, �� ���������������� ��� ������� tier
    public int[] enemiesPerTier = new int[] { 10, 6, 3, 1 };

    // �������� ���������: ����� ������ ������ ��� ��� ������
    private List<List<GameObject>> enemyPools;

    private void Awake()
    {
        // ���������� ������ ����
        enemyPools = new List<List<GameObject>>();
        // ��� ������� ������� ��������� ������� ������-���
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            enemyPools.Add(new List<GameObject>());
        }
        // ���������� ����� ��� ��������� �������� ������.
        // ����������, �� ����� ������ ������ ��������� EnemyAgent ��
        // ����� currentTier
        for(int i = 0; i < enemyPools.Count; i++)
        {
            GameObject prefab = enemyPrefabs[i];
            int tier = prefab.GetComponent<EnemyAgent>().currentTier;
            // ������� tier ����������� � 1, � ������� ������ - � 0:
            int countForThisPrefab = enemiesPerTier[tier - 1];
            for (int j = 0; j < countForThisPrefab; j++)
            {
                // ��������� ������ �� ������� ��������
                GameObject enemy = Instantiate(prefab, transform.position,
                    Quaternion.identity);
                enemy.SetActive(false); // ������� ������ ����������
                enemyPools[i].Add(enemy);
            }
        }
    }
    private void Start()
    {
        // ��������� �������, ��� ��������� ������ ������ � ������� ����
        StartCoroutine(ActivateSpawn());
    }
    private IEnumerator ActivateSpawn()
    {
        // ��������� �� ������� ���� ������
        foreach (List<GameObject> pool in enemyPools)
        {
            // ��������� ������� ������ � ��������� ���� � ���������
            foreach (GameObject enemy in pool)
            {
                enemy.SetActive(true);
                yield return new WaitForSeconds(spawnEnemyDelay);
            }
            // ϳ��� ���������� ���� - ��������
            yield return new WaitForSeconds(spawnWaveDelay);
        }
        // �������� �������
        gameObject.SetActive(false);
    }
}
