using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWavesUPD : MonoBehaviour
{
    [Header("Префаби ворогів")]
    // Список префабів ворогів, які потрібно спавнити
    public List<GameObject> enemyPrefabs;

    [Header("Налаштування спавну")]
    // Затримка між хвилями (після завершення спавну кожного пулу
    public float spawnWaveDelay = 15f;
    // Затримка між спавном окремих ворогів усередині хвилі
    public float spawnEnemyDelay = 2f;
    // Масив для кількості ворогів, які створюватимуться для кожного tier
    public int[] enemiesPerTier = new int[] { 10, 6, 3, 1 };

    // Динамічна структура: кожег префаб отримує свій пул ворогів
    private List<List<GameObject>> enemyPools;

    // Поточна хвиля
    [HideInInspector]public int currentWaveCount = 0;

    private void Awake()
    {
        // Ініціалізуємо список пулів
        enemyPools = new List<List<GameObject>>();
        // Для кожного префабу створюємо окремий список-пул
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            enemyPools.Add(new List<GameObject>());
        }
        // Заповнюємо кожен пул відповідною кількістью ворогів.
        // Припускаємо, що кожен префаб містить компонент EnemyAgent із
        // полем currentTier
        for(int i = 0; i < enemyPools.Count; i++)
        {
            GameObject prefab = enemyPrefabs[i];
            int tier = prefab.GetComponent<EnemyAgent>().currentTier;
            // Оскільки tier починаються з 1, а індекси масиву - з 0:
            int countForThisPrefab = enemiesPerTier[tier - 1];

            for (int j = 0; j < countForThisPrefab; j++)
            {
                // Створюємо ворога на позиції спавнера
                GameObject enemy = Instantiate(prefab, transform.position,
                    Quaternion.identity);
                enemy.SetActive(false); // Зробити ворога неактивним
                enemyPools[i].Add(enemy);
            }
        }
    }
    private void Start()
    {
        // Запускаємо корутіну, яка послідовно активує ворогів з кожного пулу
        StartCoroutine(ActivateSpawn());
        WavesCount.Instance.CountTotalWave(enemyPrefabs);
    }
    private IEnumerator ActivateSpawn()
    {
        WavesCount.Instance.CountCurrentWave();
        currentWaveCount++; // Додаємо 1 до поточного значення.
        // Проходимо по кожному пулу ворогів
        foreach (List<GameObject> pool in enemyPools)
        {
            // Активація кожного ворога з поточного пулу з затримкою
            foreach (GameObject enemy in pool)
            {
                enemy.SetActive(true);
                yield return new WaitForSeconds(spawnEnemyDelay);
            }
            // Після завершення хвилі - затримка
            yield return new WaitForSeconds(spawnWaveDelay);
        }
        // Додаємо фоундейшени в кінці хвилі
        Economy.Instance.AddFoundationsPerWave();
        
        // Вимикаємо спавнер
        gameObject.SetActive(false);
    }
}
