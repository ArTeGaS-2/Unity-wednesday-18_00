using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Core : MonoBehaviour
{
    public static Core Instance; // Сінглтон

    public TextMeshProUGUI coreHpText; // Текст - індикатор хп
    public Slider coreHpSlider; // Полоса - індикатор хп

    public int maxHp = 4000; // Максимальне хп ядра
    private int currentHp; // Поточне значення хп ядра

    private bool canTakeDamage = true; // Індикатор того, чи може ядро отримати дмг

    private int enemiesInTrigger = 0; // Кількість ворогів у зоні тригеру
    private void Awake()
    {
        Instance = this; // Розміщуємо екземпляр в змінній
    }
    private void Start()
    {
        currentHp = maxHp; // Встановлюємо поточне хп як масимальне
        // Встановлюємо в текст поточні значення
        coreHpText.text = $"{currentHp} / {maxHp}";
        // Примусово встановлюємо пікові значення слайдеру
        coreHpSlider.maxValue = maxHp; // Максимальне хп в слайдері
        coreHpSlider.minValue = 0; // Мінімальне хп в слайдері
        coreHpSlider.value = currentHp; // Поточне хп в слайдері
        StartCoroutine(DamageOverTime());
    }
    IEnumerator DamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (enemiesInTrigger > 0) // Якщо ворогів більше 0
            {
                int totalDamage = 5 * enemiesInTrigger; // Кількість ДМГ
                currentHp -= totalDamage; // Знімає ХП
                if (currentHp < 0) currentHp = 0; // Щоб хп було не менше 0

                //UpdateSliderAndText();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) enemiesInTrigger++;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Не дає кількості бути відмінною, але знижує за кожен вихід
            enemiesInTrigger = Mathf.Max(0, enemiesInTrigger - 1);
        }
    }
    public void UpdateSliderAndText()
    {
        coreHpText.text = $"{currentHp} / {maxHp}";
        coreHpSlider.value = currentHp;
    }
}
