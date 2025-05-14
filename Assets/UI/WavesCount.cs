using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WavesCount : MonoBehaviour
{
    public static WavesCount Instance; // Сінглтон  

    public TextMeshProUGUI wavesCountText; // Посилання на об'єкт тексту

    public int waveStageCounter = 0; // Лічильник поточної кількості спавнерів
    public int waveStageTotal= 0; // Загальна кількість спавнерів

    public int waveCounter = 0; // Лічильник хвиль у спавнері
    public int waveTotalInStage = 0; // Загалом в поточному спавнері
    private void Awake()
    {
        Instance = this;

        waveStageTotal = FindObjectsOfType<EnemyWavesUPD>(true).Length;
        SetText();
        wavesCountText.gameObject.SetActive(false);
    }
    private void SetText()
    {
        wavesCountText.text = $"Хвилі: {waveCounter}/{waveTotalInStage}" +
            $" - Стадія: {waveStageCounter}/{waveStageTotal}";
    }
    public void CountTotalWave(List<GameObject> prefabList)
    {
        // Поточну кількість хвиль у конкретному спавнері
        waveTotalInStage = prefabList.Count;
        SetText();
    }
    public void CountCurrentWave()
    {
        waveCounter++; // Додає до поточної хвилі 1
        SetText();
    }
    public void CountTotalStages(List<GameObject> stageList)
    {
        // Рахуємо загальну кількість спавнерів
        waveStageTotal = stageList.Count;
        SetText();
    }
    public void CountCurrentStage()
    {
        // Рахуємо поточний Стейдж/Спавнер
        waveStageCounter++;
        SetText();
    }
    public void ResetWaveCounter()
    {
        waveCounter = 0;
        SetText();
    }
}
