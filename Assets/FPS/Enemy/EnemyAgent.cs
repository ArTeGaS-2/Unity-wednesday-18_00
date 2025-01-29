using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAgent : MonoBehaviour
{
    public string targetName;
    public Slider hitPoints;

    public int currentTier;

    private GameObject target;
    private NavMeshAgent agent; // ����� ��� ���������� NavMeshAgent

    public int maxHitPoints = 5; // ����������� ������� ��

    private void Start()
    {
        // ������� ����������� ������� �� (��������)
        hitPoints.maxValue = maxHitPoints;
        // ������� ������� �������� ��
        hitPoints.value = maxHitPoints;
        
        target = GameObject.Find(targetName);
        agent = GetComponent<NavMeshAgent>(); // ��������� ���������� NavMeshAgent
        if (target != null)
        {
            agent.SetDestination(target.transform.position); // ������������ ������ ����� �������� ��� NavMeshAgent
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == target)
        {
            Debug.Log("Core are in danger!");
            StartCoroutine(StopMoving());
        }
    }

    IEnumerator StopMoving()
    {
        agent.isStopped = true; // ������� NavMeshAgent
        yield return new WaitForSeconds(3f);
        agent.isStopped = false; // ³��������� ���� NavMeshAgent
    }
}