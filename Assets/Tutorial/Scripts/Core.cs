using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
    public int MaxHP = 10;
    private int HP;

    public UnityEvent<string> OnHPChanged;
    public UnityEvent OnHit;
    public UnityEvent OnDestroy;

    private static Core _Instance;
    public static Core Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = GameObject.FindObjectOfType<Core>();
            return _Instance;
        }
    }

    private void Awake()
    {
        _Instance = this;
    }

    private void OnEnable()
    {
        HP = MaxHP;
        UpdateUI();
    }

    public void OnTriggerEnter(Collider other)
    {
        var Mob = other.GetComponent<Mob>();
        if (Mob != null)
        {
            OnHit?.Invoke();
            DecreaseHP(1);
            Mob.Destroy();
        }
    }

    private void DecreaseHP(int Amount)
    {
        if (HP <= 0) return;

        HP -= Amount;
        if (HP <= 0)
        {
            HP = 0;
            OnDestroy?.Invoke();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        OnHPChanged?.Invoke($"HP : {HP}");
    }
}
