using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // ������� ������
    public GameObject emptySpawnPoint; // ����� ������
    // ���� ��'����
    private List<GameObject> enemyPool_1;
    private List<GameObject> enemyPool_2;
    private List<GameObject> enemyPool_3;
    private List<GameObject> enemyPool_4;
    private List<GameObject> enemyPool_5;

    private int currentPoolIndex = 0; // �������� ����

    public int waveCount; // ʳ������ �����

    // ʳ������ ������ �� Tier
    private int waveTier_1 = 10;
    private int waveTier_2 = 6;
    private int waveTier_3 = 3;
    private int waveTier_4 = 1;

    private int currentTier;

    private int currentWave = 1;

    public float spawnWaveDelay = 15f;
    private void Awake()
    {
        // �������� ���� �������� ��� ����� ���
        SpawnWave();
    }
    private void Start()
    {
        StartCoroutine(ActivateSpawn());
    }
    private void SpawnWave()
    {
        // ���� �� �������� ������� ������
        foreach (GameObject enemyObj in enemyPrefabs)
        {
            // ������� Tier ��������� ������
            switch (enemyObj.gameObject.GetComponent<EnemyAgent>().currentTier)
            {
                case 1:
                    currentTier = waveTier_1;
                    break;
                case 2:
                    currentTier = waveTier_2;
                    break;
                case 3:
                    currentTier = waveTier_3;
                    break;
                case 4:
                    currentTier = waveTier_4;
                    break;
            }
            // ������� �� �������� ���������� ����� �������
            for (int i = 0; i < currentTier; i++)
            {
                GameObject currentObj = Instantiate(
                    enemyObj, transform.position, Quaternion.identity);

                currentObj.SetActive(false);
                // ���� ��������� �� ����
                switch (currentPoolIndex)
                {
                    case 0:
                        enemyPool_1.Add(currentObj);
                        break;
                    case 1:
                        enemyPool_2.Add(currentObj);
                        break;
                    case 2:
                        enemyPool_3.Add(currentObj);
                        break;
                    case 3:
                        enemyPool_4.Add(currentObj);
                        break;
                    case 4:
                        enemyPool_5.Add(currentObj);
                        break;

                }
            }
            // ������� ������ ���������� �������
            currentPoolIndex++;
        }
        // ���� ������ ��������� �����
        currentWave++;
    }
    private IEnumerator ActivateSpawn()
    {
        foreach (GameObject obj in enemyPool_1)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(spawnWaveDelay);
        foreach (GameObject obj in enemyPool_2)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(spawnWaveDelay);
        foreach (GameObject obj in enemyPool_3)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(spawnWaveDelay);
        foreach (GameObject obj in enemyPool_4)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(spawnWaveDelay);
        foreach (GameObject obj in enemyPool_5)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
    }
    private void Update()
    {
        
    }
}
