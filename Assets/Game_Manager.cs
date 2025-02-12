using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;

    [Header("Налаштування рівня")]
    public List<GameObject> listOfSpawners; // Список спавнерів рівню

    [Header("Ігрові об'єкти")]
    public GameObject weapon;
    public GameObject buildInterface;

    // Ігрові режими: "Builder" та "Shooter"
    private string currentGameMode = "Builder";
    private string secondGameMode = "Shooter";

    // Індекс наступного спавнера для активації
    private int nextSpawnerIndex = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // На старті гри встановлюємо режим Builder
        currentGameMode = "Builder";
        weapon.SetActive(false);
        buildInterface.SetActive(true);
        // Всі спавнери відключені 
        foreach (GameObject spawner in listOfSpawners)
        {
            spawner.SetActive(false);
        }
    }
    private void Update()
    {
        // Якщо натиснуто Enter, режим Builder і немає активних
        // спавнерів - активуємо наступний спавнер
        if (Input.GetKeyDown(KeyCode.Return) &&
            currentGameMode == "Builder" &&
            NoActiveSpawner())
        {
            ActivateSpawner();
        }
    }
    // Допоміжний метод для перевірки, що жоден спавнер не активний
    bool NoActiveSpawner()
    {
        // Перебираємо всі спавнери
        foreach (GameObject spawner in listOfSpawners)
        {
            if (spawner.activeSelf) return false;
        }
        return true;
    }
    void ActivateSpawner()
    {
        if (nextSpawnerIndex < listOfSpawners.Count)
        {
            // Активуємо спавнер за поточним індексом
            listOfSpawners[nextSpawnerIndex].SetActive(true);
            Debug.Log("Активовано спавнер №" + (nextSpawnerIndex + 1));
            nextSpawnerIndex++;

            // Перемикаємо режим на Shooter: активуємо зброю,
            // вимикаємо інтерфейс Builder
            currentGameMode = "Shooter";
            weapon.SetActive(true);
            buildInterface.SetActive(false);
            Debug.Log("Режим змінено на Shooter.");
        }
        else
        {
            Debug.Log("Більше немає спавнерів для активації.");
        }
    }
    void SwitchToBuilder()
    {
        currentGameMode = "Builder";
        weapon.SetActive(false);
        buildInterface.SetActive(true);
        Debug.Log("Хвиля завершена. Режим змінено на Builder.");
    }

}
