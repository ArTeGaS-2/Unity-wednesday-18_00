using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public static Economy Instance; // ѳ������

    public int foundations = 8; // ���������� ������ � �� �������
    public int credits = 500; // ʳ������ ������� 

    public int foundationsPerWave = 6; // ���������� �� �����

    public int turretPrice = 100; // ֳ�� �� ����������� ������

    public TextMeshProUGUI foundationsText;
    public TextMeshProUGUI creditsText;

    public GameObject economyUI;
    public void AddFoundationsPerWave()
    {
        // ������ ���� ���� ����������� ��� ����������
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
    // ���� ������� �� ��������
    public void CreditsForKillsEnemies(int price)
    {
        credits += price; // ������ �������
        creditsText.text = credits.ToString(); // ��������� �����
    }
}
