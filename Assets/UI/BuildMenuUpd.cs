using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuUpd : MonoBehaviour
{
    public Camera playerCamera;

    // Посилання на три RawImage об'єкти, які представляють рамки піктограм
    public RawImage frame1;
    public RawImage frame2;
    public RawImage frame3;

    public GameObject buildText;
    public GameObject destructText;
    public GameObject turretPanel;
    public GameObject upgradeMenu;

    private int currentFrameUI = 1;

    // Колір для виділення та колір за замовчуванням
    private Color highlightColor = Color.yellow;
    private Color defaultColor = Color.white;

    // Поточний об'єкт (в фокусі камери)
    private GameObject currentObject;
    // Посилання на префаби
    public GameObject foundation;
    public GameObject turret_1;
    public GameObject turret_2;
    public GameObject turret_3;

    // Модифікатор висоти турелей
    public float turretHeightMod = -0.2f;
    public float foundationHeightMod = 0f;
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20000f) &&
            Game_Manager.Instance.currentGameMode == "Builder")
        {
            currentObject = hit.collider.gameObject;
            if (hit.collider.CompareTag("Frame") &&
                !hit.collider.gameObject.GetComponent<FrameObj>(
                    ).ifFoundationSet)
            {
                IfItsFrame(currentObject);
                buildText.SetActive(true);
            }
            else
            {
                buildText.SetActive(false);
            }

            if (hit.collider.CompareTag("Foundation") &&
                !hit.collider.gameObject.GetComponent<FoundationBlock>(
                    ).ifTurretCreated)
            {
                IfItsFoundation(currentObject);
                turretPanel.SetActive(true);
                Select_1_Turret();
                Select_2_Turret();
                Select_3_Turret();
            }
            else
            {
                turretPanel.SetActive(false);
            }

            if (hit.collider.CompareTag("Turret_1") ||
                hit.collider.CompareTag("Turret_2") ||
                hit.collider.CompareTag("Turret_3"))
            {
                IfItsTurret();
            }
        }
    }
    private void IfItsFrame(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.E) &&
            Economy.Instance.foundations > 0)
        {
            Vector3 spawnPoint = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + foundationHeightMod,
                obj.transform.position.z);
            Instantiate(foundation, spawnPoint, obj.transform.rotation);
            obj.GetComponent<FrameObj>().ifFoundationSet = true;
            // Додаємо виклик економіки
            Economy.Instance.MinusFoundation();
        }
    }
    private void IfItsFoundation(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.E) && currentFrameUI == 1 &&
            Economy.Instance.credits >= Economy.Instance.turretPrice)
        {
            Vector3 spawnPoint = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + turretHeightMod,
                obj.transform.position.z);
            Instantiate(turret_1, spawnPoint, obj.transform.rotation);
            // Перемикає стан флага турелі
            obj.GetComponent<FoundationBlock>().ifTurretCreated = true;
            // Виклик економіки
            Economy.Instance.MinusCredits();
        }
        else if(Input.GetKeyDown(KeyCode.E) && currentFrameUI == 2 &&
            Economy.Instance.credits >= Economy.Instance.turretPrice)
        {
            Vector3 spawnPoint = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + turretHeightMod,
                obj.transform.position.z);
            Instantiate(turret_2, spawnPoint, obj.transform.rotation);
            // Перемикає стан флага турелі
            obj.GetComponent<FoundationBlock>().ifTurretCreated = true;
            // Виклик економіки
            Economy.Instance.MinusCredits();
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentFrameUI == 3 &&
            Economy.Instance.credits >= Economy.Instance.turretPrice)
        {
            Vector3 spawnPoint = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + turretHeightMod,
                obj.transform.position.z);
            Instantiate(turret_3, spawnPoint, obj.transform.rotation);
            // Перемикає стан флага турелі
            obj.GetComponent<FoundationBlock>().ifTurretCreated = true;
            // Виклик економіки
            Economy.Instance.MinusCredits();
        }
    }
    private void IfItsTurret()
    {

    }
    void SelectFrame(int frameNumber)
    {
        // Скидання кольорів всіх рамок до білого
        frame1.color = defaultColor;
        frame2.color = defaultColor;
        frame3.color = defaultColor;

        // Встановлення кольору виділення для обраної рамки
        switch (frameNumber)
        {
            case 1:
                frame1.color = highlightColor;
                break;
            case 2:
                frame2.color = highlightColor;
                break;
            case 3:
                frame3.color = highlightColor;
                break;
        }
    }
    public void Select_1_Turret()
    {
        // Перевірка натискання клавіш
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectFrame(1);
            currentFrameUI = 1;
        }
    }
    public void Select_2_Turret()
    {
        // Перевірка натискання клавіш
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectFrame(2);
            currentFrameUI = 2;
        }
    }
    public void Select_3_Turret()
    {
        // Перевірка натискання клавіш
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectFrame(3);
            currentFrameUI = 3;
        }
    }
}
