using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MobCounterUI : MonoBehaviour
{
    private int KillCount;
    private int SpawnCount;

    private TextMeshProUGUI TextUI;

    private void Awake()
    {
        TextUI = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateUI()
    {
        if (!enabled) return;

        TextUI.text = $"Kill/Alive/Spawn\n{KillCount}/{SpawnCount - KillCount}/{SpawnCount}";
    }

    private void OnEnable()
    {
        KillCount = SpawnCount = 0;
        UpdateUI();
    }

    public void OnSpawn()
    {
        SpawnCount++;
        UpdateUI();
    }

    public void OnKill()
    {
        KillCount++;
        UpdateUI();
    }
}
