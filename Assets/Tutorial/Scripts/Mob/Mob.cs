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
        Invoke(nameof(Destroy), 3f); // 3ÃÊ ÈÄ ÀÚÆø
        OnCreated?.Invoke();
    }
    public void Destroy()
    {
        if (IsDestroyed) return;
        IsDestroyed = true;
        
        Destroy(gameObject, DestroyDelay);
        OnDestroyed?.Invoke();
    }
}
