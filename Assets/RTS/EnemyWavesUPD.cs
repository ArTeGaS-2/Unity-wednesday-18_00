using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWavesUPD : MonoBehaviour
{
    [Header("������� ������")]
    public List<Game_Manager> enemyPrefabs;

    [Header("������������ ������")]
    public float spawnWaveDelay = 15f;
}
