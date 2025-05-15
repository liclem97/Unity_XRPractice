using UnityEngine;
using UnityEngine.Events;

public class Mob : MonoBehaviour
{
    public float DestroyDelay = 1f;

    public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;

    private bool IsDestroyed = false;

    private void Start()
    {
        OnCreated?.Invoke();
        MobManager.Instance.OnSpawned(this);
    }
    public void Destroy()
    {
        if (IsDestroyed) return;
        IsDestroyed = true;
        
        Destroy(gameObject, DestroyDelay);
        OnDestroyed?.Invoke();
        MobManager.Instance.OnDestroyed(this);
    }
}
