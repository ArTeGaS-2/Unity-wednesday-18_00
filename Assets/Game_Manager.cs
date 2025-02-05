using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public List<GameObject> listOfSpawners; // Список спавнерів рівню

    private string currentGameMode = "Builder";
    private string secondGameMode = "Shooter";

    public GameObject weapon;
    public GameObject buildInterface;

    public bool canSpawnWave = true;

    private void Start()
    {
        foreach (GameObject spawner in listOfSpawners)
        {
            spawner.SetActive(true);

        }
    }
}
