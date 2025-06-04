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

    private bool canTakeDamage = true; // ��������� ����, �� ���� ���� �������� ���

    private int enemiesInTrigger = 0; // ʳ������ ������ � ��� �������
    private void Awake()
    {
        Instance = this; // �������� ��������� � �����
    }
    private void Start()
    {
        currentHp = maxHp; // ������������ ������� �� �� ����������
        // ������������ � ����� ������ ��������
        coreHpText.text = $"{currentHp} / {maxHp}";
        // ��������� ������������ ���� �������� ��������
        coreHpSlider.maxValue = maxHp; // ����������� �� � �������
        coreHpSlider.minValue = 0; // ̳������� �� � �������
        coreHpSlider.value = currentHp; // ������� �� � �������
        StartCoroutine(DamageOverTime());
    }
    IEnumerator DamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (enemiesInTrigger > 0) // ���� ������ ����� 0
            {
                int totalDamage = 5 * enemiesInTrigger; // ʳ������ ���
                currentHp -= totalDamage; // ���� ��
                if (currentHp < 0) currentHp = 0; // ��� �� ���� �� ����� 0

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
            // �� �� ������� ���� �������, ��� ����� �� ����� �����
            enemiesInTrigger = Mathf.Max(0, enemiesInTrigger - 1);
        }
    }
    public void UpdateSliderAndText()
    {
        coreHpText.text = $"{currentHp} / {maxHp}";
        coreHpSlider.value = currentHp;
    }
}
