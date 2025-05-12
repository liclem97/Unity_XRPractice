using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magazine : MonoBehaviour, IReloadable
{
    public int MaxBullets = 20;
    public float ChargineTime = 2f;

    private int _CurrentBullets;
    private int CurrentBullets
    {
        get => _CurrentBullets; // CurrentBullets 값을 가져옴
        set // CurrentBullets 값을 설정
        {
            if (value < 0)
                _CurrentBullets = 0;
            else if (value > MaxBullets)
                _CurrentBullets = MaxBullets;
            else
                _CurrentBullets = value;

            OnBulletChanged?.Invoke(_CurrentBullets);
            OnChargeChanged?.Invoke((float)_CurrentBullets / MaxBullets);
        }
    }

    public UnityEvent OnReloadStart;
    public UnityEvent OnReloadEnd;

    public UnityEvent<int> OnBulletChanged;
    public UnityEvent<float> OnChargeChanged;

    private void Start()
    {
        CurrentBullets = MaxBullets;
    }

    public bool Use(int Amount = 1)
    {
        if (CurrentBullets >= Amount)
        {
            CurrentBullets -= Amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartReload()
    {
        if (CurrentBullets == MaxBullets) return;

        StopAllCoroutines();
        StartCoroutine(ReloadPrecess());
    }

    public void StopReload()
    {
        StopAllCoroutines();
    }

    private IEnumerator ReloadPrecess()
    {
        OnReloadStart?.Invoke();

        var BeginTime = Time.time;
        var BeginBullets = CurrentBullets;
        var EnoughPercent = 1f - ((float)CurrentBullets / MaxBullets);
        var EnoughChargineTime = ChargineTime * EnoughPercent;

        while (true)
        {   
            var T = (Time.time - BeginTime) / EnoughChargineTime;
            if (T >= 1f) break;

            CurrentBullets = (int)Mathf.Lerp(BeginBullets, MaxBullets, T);
            yield return null;
        }

        CurrentBullets = MaxBullets;

        OnReloadEnd?.Invoke();
    }
}
