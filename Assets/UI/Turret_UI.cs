using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turret_UI : MonoBehaviour
{
    public static Turret_UI instance;
    public GameObject upgrade_buy_UI;

    [Header("Текстові елементи")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DPS_Text;
    public TextMeshProUGUI radiusText;
    public TextMeshProUGUI DMG_Type_Text;
    public TextMeshProUGUI priceText;


}
