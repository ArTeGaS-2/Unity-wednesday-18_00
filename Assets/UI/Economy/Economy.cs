using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public static Economy Instance;

    public int foundations = 8;
    public int credits = 500;

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
    }
    public void MinusCredits()
    {
        credits = credits - 100;
    }

}
