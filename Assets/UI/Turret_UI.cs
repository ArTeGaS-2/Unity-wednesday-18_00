using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turret_UI : MonoBehaviour
{
    public static Turret_UI instance; // ѳ������
    public GameObject upgrade_buy_UI; // UI ���� ���������� �����

    [Header("������� ��������")]
    public TextMeshProUGUI nameText; // �����
    public TextMeshProUGUI DPS_Text; // ���� �� ������
    public TextMeshProUGUI radiusText; // �������� ������
    public TextMeshProUGUI DMG_Type_Text; // ��� �����
    public TextMeshProUGUI priceText; // ֳ����

    private Turret currentTurret; // ������� ������
    private void Start()
    {
        instance = this;
    }
    public void Turret_Info(RaycastHit hit)
    {
        // �������� ��������� �� ������ ����� ��� ������� �����
        currentTurret = hit.collider.gameObject.
            GetComponent<Turret>();

        // ��'� �����
        nameText.text = currentTurret.turretName;
        // ������ �� �������
        DPS_Text.text = (currentTurret.turretDamage *
            currentTurret.turretAttackSpeed).ToString();
        // ����� �����
        radiusText.text = currentTurret.turretRange.ToString();
        // ��� �����
        DMG_Type_Text.text = currentTurret.turretDamageType;
        // ֳ�� �����
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
