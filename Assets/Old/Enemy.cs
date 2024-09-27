using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string targetName;

    private GameObject target;
    private NavMeshAgent agent;

    private void Start()
    {
        target = GameObject.Find(targetName);
        agent = GetComponent<NavMeshAgent>();
    }
}
