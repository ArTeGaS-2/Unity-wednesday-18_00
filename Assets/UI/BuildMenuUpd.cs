using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BuildMenuUpd : MonoBehaviour
{
    public Camera playerCamera;
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20000f))
        {
            if (hit.collider.CompareTag("Frame"))
            {
                IfItsFrame();
            }
            if (hit.collider.CompareTag("Foundation"))
            {
                IfItsFoundation();
            }

            if (hit.collider.CompareTag("Turret_1") ||
                hit.collider.CompareTag("Turret_2") ||
                hit.collider.CompareTag("Turret_3"))
            {
                IfItsTurret();
            }
        }
    }
    private void IfItsFrame()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Воно працює!");
        }
    }
    private void IfItsFoundation()
    {

    }
    private void IfItsTurret()
    {

    }
}
