using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public static Economy Instance; // Сінглтон

    public int foundations = 8; // Фундаменти поточні і на початку
    public int credits = 500; // Кількість кредитів 

    public int foundationsPerWave = 6; // Фундаменти за хвилю

    public int turretPrice = 100; // Ціна за встановлену турель

    public TextMeshProUGUI foundationsText;
    public TextMeshProUGUI creditsText;

    public GameObject economyUI;
    public void AddFoundationsPerWave()
    {
        // Додаємо після хвилі фоундейшени для будівництіва
        foundations += foundationsPerWave;
        foundationsText.text = foundations.ToString();
    }
    private void Start()
    {
        Instance = this;

        foundationsText.text = foundations.ToString();
        creditsText.text = credits.ToString();
    }
    public void MinusFoundation()
    {
        foundations--;
        foundationsText.text = foundations.ToString();
    }
    public void MinusCredits()
    {
        credits = credits - turretPrice;
        creditsText.text = credits.ToString();
    }
    // Додає кредити за вбивство
    public void CreditsForKillsEnemies(int price)
    {
        credits += price; // Додаємо кредити
        creditsText.text = credits.ToString(); // Оновлюємо текст
    }
}
