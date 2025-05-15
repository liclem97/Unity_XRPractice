using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTimeUI : MonoBehaviour
{
    private float StartTime;

    private TextMeshProUGUI TextUI;

    private void Awake()
    {
        TextUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartTime = Time.time;
    }

    private void Update()
    {
        TextUI.text = $"Survival Time\n{Time.time - StartTime:0.0}s";
    }
}
