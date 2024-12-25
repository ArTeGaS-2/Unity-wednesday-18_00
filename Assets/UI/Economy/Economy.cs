using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public static Economy Instance; // Сінглтон

    public int foundations = 8;
    public int credits = 500;
    public int baseEnemyPrice = 10; // Базова ціна за ворога

    public int turretPrice = 100;

    public TextMeshProUGUI foundationsText;
    public TextMeshProUGUI creditsText;

    public GameObject economyUI;

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
    public void CreditsForKillsEnemies()
    {
        credits += baseEnemyPrice; // Додаємо кредити
        creditsText.text = credits.ToString(); // Оновлюємо текст
    }
}
