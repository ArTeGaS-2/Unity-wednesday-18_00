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
    private NavMeshAgent agent; // Змінна для компонента NavMeshAgent

    public int maxHitPoints = 5; // Максимальна кількість ХП

    private void Start()
    {
        // Визначає максимальну кількість ХП (здоровья)
        hitPoints.maxValue = maxHitPoints;
        // Визначає поточне значення ХП
        hitPoints.value = maxHitPoints;
        
        target = GameObject.Find(targetName);
        agent = GetComponent<NavMeshAgent>(); // Отримання компонента NavMeshAgent
        if (target != null)
        {
            agent.SetDestination(target.transform.position); // Встановлення кінцевої точки маршруту для NavMeshAgent
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
        agent.isStopped = true; // Зупинка NavMeshAgent
        yield return new WaitForSeconds(3f);
        agent.isStopped = false; // Відновлення руху NavMeshAgent
    }
}