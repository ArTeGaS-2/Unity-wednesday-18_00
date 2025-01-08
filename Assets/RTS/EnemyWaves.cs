using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Шаблони ворогів
    public GameObject emptySpawnPoint; // Точка спавну

    public int waveCount; // Кількість хвиль

    // Кількість ворогів на Tier
    private int waveTier_1 = 10;
    private int waveTier_2 = 6;
    private int waveTier_3 = 3;
    private int waveTier_4 = 1;

    private int currentTier;
    private void Start()
    {
        foreach (GameObject enemyObj in enemyPrefabs)
        {
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
            for(int i = 0; i < currentTier; i++)
            {
                Instantiate(enemyObj, transform.position, Quaternion.identity);
            }
        }
    }
    private void Update()
    {
        
    }
}
