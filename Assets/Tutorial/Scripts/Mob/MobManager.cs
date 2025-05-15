using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobManager : MonoBehaviour
{
    private static MobManager _Instance;

    public static MobManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType<MobManager>();
            }
            return _Instance;
        }
    }

    public UnityEvent<Mob> OnSpawn, OnDestroy;

    private List<Mob> Mobs = new List<Mob>();

    private void Awake()
    {
        _Instance = this;
    }

    public void OnSpawned(Mob mob)
    {
        Mobs.Add(mob);
        OnSpawn?.Invoke(mob);
    }

    public void OnDestroyed(Mob mob)
    {
        if (Mobs.Remove(mob))
        {
            OnDestroy?.Invoke(mob);
        }
    }

    public void DestroyAll()
    {
        while (Mobs.Count > 0)
        {
            Mobs[0]?.Destroy();
        }
    }
}
