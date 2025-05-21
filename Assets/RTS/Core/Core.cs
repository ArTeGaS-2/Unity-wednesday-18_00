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

    private void Start()
    {
        currentHp = maxHp; // Встановлюємо поточне хп як масимальне

        // Встановлюємо в текст поточні значення
        coreHpText.text = $"{currentHp} / {maxHp}";
        // Примусово встановлюємо пікові значення слайдеру
        coreHpSlider.maxValue = maxHp; 
        coreHpSlider.minValue = 0;


    }

}
