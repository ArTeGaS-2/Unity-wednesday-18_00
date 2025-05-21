using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Core : MonoBehaviour
{
    public static Core Instance; // ѳ������

    public TextMeshProUGUI coreHpText; // ����� - ��������� ��
    public Slider coreHpSlider; // ������ - ��������� ��

    public int maxHp = 4000; // ����������� �� ����
    private int currentHp; // ������� �������� �� ����

    private void Start()
    {
        currentHp = maxHp; // ������������ ������� �� �� ����������

        // ������������ � ����� ������ ��������
        coreHpText.text = $"{currentHp} / {maxHp}";
        // ��������� ������������ ���� �������� ��������
        coreHpSlider.maxValue = maxHp; 
        coreHpSlider.minValue = 0;


    }

}
