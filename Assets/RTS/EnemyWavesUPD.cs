using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWavesUPD : MonoBehaviour
{
    [Header("Префаби ворогів")]
    public List<Game_Manager> enemyPrefabs;

    [Header("Налаштування спавну")]
    public float spawnWaveDelay = 15f;
}
