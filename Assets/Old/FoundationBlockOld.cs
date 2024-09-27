using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationBlockOld : MonoBehaviour
{
    public bool cubeState = false;
    //public bool turretState = false;

    GameObject cube;
    //GameObject turret;

    private void Start()
    {
        cube = transform.Find("Foundation")?.gameObject;
        //turret = transform.Find("Turret")?.gameObject;
    }
    private void Update()
    {
        if (cubeState)
        {
            cube.SetActive(true);
        }
        else if (!cubeState)
        {
            cube.SetActive(false);
        }
    }
}
