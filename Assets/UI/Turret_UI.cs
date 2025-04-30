using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turret_UI : MonoBehaviour
{
    public static Turret_UI instance; // Сінглтон
    public GameObject upgrade_buy_UI; // UI вікно інформації турелі

    [Header("Текстові елементи")]
    public TextMeshProUGUI nameText; // Назва
    public TextMeshProUGUI DPS_Text; // урон за сеунду
    public TextMeshProUGUI radiusText; // Показник радіусу
    public TextMeshProUGUI DMG_Type_Text; // Тип урону
    public TextMeshProUGUI priceText; // Цінник

    private Turret currentTurret; // Виділена турель
    private void Start()
    {
        instance = this;
    }
    public void Turret_Info(RaycastHit hit)
    {
        // Отримуємо посилання на скрипт турелі для поточної турелі
        currentTurret = hit.collider.gameObject.
            GetComponent<Turret>();

        // Ім'я турелі
        nameText.text = currentTurret.turretName;
        // Демедж за секунду
        DPS_Text.text = (currentTurret.turretDamage *
            currentTurret.turretAttackSpeed).ToString();
        // Радіус атаки
        radiusText.text = currentTurret.turretRange.ToString();
        // Тип урону
        DMG_Type_Text.text = currentTurret.turretDamageType;
        // Ціна турелі
        priceText.text = currentTurret.baseBuildPrice.ToString();
    }
    public void Turret_Window_Activate()
    {
        upgrade_buy_UI.SetActive(true);
    }
    public void Turret_Window_Deactivate()
    {
        upgrade_buy_UI.SetActive(false);
    }
}
