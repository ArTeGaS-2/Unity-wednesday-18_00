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
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20000f) && FPS_Move.gameMode == "Builder")
        {
            currentObject = hit.collider.gameObject;
            if (hit.collider.CompareTag("Frame"))
            {
                IfItsFrame(currentObject);
                buildText.SetActive(true);
            }
            else
            {
                buildText.SetActive(false);
            }

            if (hit.collider.CompareTag("Foundation"))
            {
                IfItsFoundation(currentObject);
                turretPanel.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 spawnPoint = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + 0.38f,
                obj.transform.position.z);
            Instantiate(foundation, spawnPoint, obj.transform.rotation);
        }
    }
    private void IfItsFoundation(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.E) && currentFrameUI == 1)
        {
            Vector3 spawnPoint = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + turretHeightMod,
                obj.transform.position.z);
            Instantiate(turret_1, spawnPoint, obj.transform.rotation);
        }
        else if(Input.GetKeyDown(KeyCode.E) && currentFrameUI == 2)
        {
            Vector3 spawnPoint = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + turretHeightMod,
                obj.transform.position.z);
            Instantiate(turret_2, spawnPoint, obj.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentFrameUI == 3)
        {
            Vector3 spawnPoint = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + turretHeightMod,
                obj.transform.position.z);
            Instantiate(turret_3, spawnPoint, obj.transform.rotation);
        }
    }
    private void IfItsTurret()
    {

    }
}
