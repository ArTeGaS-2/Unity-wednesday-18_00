using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WavesCount : MonoBehaviour
{
    public static WavesCount Instance; // ѳ������  

    public TextMeshProUGUI wavesCountText; // ��������� �� ��'��� ������

    public int waveStageCounter = 0; // ˳������� ������� ������� ��������
    public int waveStageTotal= 0; // �������� ������� ��������

    public int waveCounter = 0; // ˳������� ����� � �������
    public int waveTotalInStage = 0; // ������� � ��������� �������
    private void Awake()
    {
        Instance = this;

        waveStageTotal = FindObjectsOfType<EnemyWavesUPD>(true).Length;
        SetText();
        wavesCountText.gameObject.SetActive(false);
    }
    private void SetText()
    {
        wavesCountText.text = $"����: {waveCounter}/{waveTotalInStage}" +
            $" - �����: {waveStageCounter}/{waveStageTotal}";
    }
    public void CountTotalWave(List<GameObject> prefabList)
    {
        // ������� ������� ����� � ����������� �������
        waveTotalInStage = prefabList.Count;
        SetText();
    }
    public void CountCurrentWave()
    {
        waveCounter++; // ���� �� ������� ���� 1
        SetText();
    }
    public void CountTotalStages(List<GameObject> stageList)
    {
        // ������ �������� ������� ��������
        waveStageTotal = stageList.Count;
        SetText();
    }
    public void CountCurrentStage()
    {
        // ������ �������� ������/�������
        waveStageCounter++;
        SetText();
    }
    public void ResetWaveCounter()
    {
        waveCounter = 0;
        SetText();
    }
}
