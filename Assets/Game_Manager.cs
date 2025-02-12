using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;

    [Header("������������ ����")]
    public List<GameObject> listOfSpawners; // ������ �������� ����

    [Header("����� ��'����")]
    public GameObject weapon;
    public GameObject buildInterface;

    // ����� ������: "Builder" �� "Shooter"
    private string currentGameMode = "Builder";
    private string secondGameMode = "Shooter";

    // ������ ���������� �������� ��� ���������
    private int nextSpawnerIndex = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // �� ����� ��� ������������ ����� Builder
        currentGameMode = "Builder";
        weapon.SetActive(false);
        buildInterface.SetActive(true);
        // �� �������� �������� 
        foreach (GameObject spawner in listOfSpawners)
        {
            spawner.SetActive(false);
        }
    }
    private void Update()
    {
        // ���� ��������� Enter, ����� Builder � ���� ��������
        // �������� - �������� ��������� �������
        if (Input.GetKeyDown(KeyCode.Return) &&
            currentGameMode == "Builder" &&
            NoActiveSpawner())
        {
            ActivateSpawner();
        }
    }
    // ��������� ����� ��� ��������, �� ����� ������� �� ��������
    bool NoActiveSpawner()
    {
        // ���������� �� ��������
        foreach (GameObject spawner in listOfSpawners)
        {
            if (spawner.activeSelf) return false;
        }
        return true;
    }
    void ActivateSpawner()
    {
        if (nextSpawnerIndex < listOfSpawners.Count)
        {
            // �������� ������� �� �������� ��������
            listOfSpawners[nextSpawnerIndex].SetActive(true);
            Debug.Log("���������� ������� �" + (nextSpawnerIndex + 1));
            nextSpawnerIndex++;

            // ���������� ����� �� Shooter: �������� �����,
            // �������� ��������� Builder
            currentGameMode = "Shooter";
            weapon.SetActive(true);
            buildInterface.SetActive(false);
            Debug.Log("����� ������ �� Shooter.");
        }
        else
        {
            Debug.Log("������ ���� �������� ��� ���������.");
        }
    }
    void SwitchToBuilder()
    {
        currentGameMode = "Builder";
        weapon.SetActive(false);
        buildInterface.SetActive(true);
        Debug.Log("����� ���������. ����� ������ �� Builder.");
    }

}
