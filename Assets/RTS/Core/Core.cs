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

    private void Start()
    {
        currentHp = maxHp; // ������������ ������� �� �� ����������

        // ������������ � ����� ������ ��������
        coreHpText.text = $"{currentHp} / {maxHp}";
        // ��������� ������������ ���� �������� ��������
        coreHpSlider.maxValue = maxHp; 
        coreHpSlider.minValue = 0;

        //StartCoroutine(TakeDamageIndicatorSwitch());
    }
    IEnumerator TakeDamageIndicatorSwitch()
    {
        while (true)
        {
            canTakeDamage = true;
            yield return new WaitForSeconds(0.1f);
            canTakeDamage = false;
        }
    }
    void DoDamage()
    {
        if (canTakeDamage)
        {
            currentHp -= 5;
            coreHpText.text = $"{currentHp} / {maxHp}";
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DoDamage();
            Debug.Log("123");
        }
    }
}
