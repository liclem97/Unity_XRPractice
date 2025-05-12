using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Shooter : MonoBehaviour
{
    public LayerMask HittableMask;
    public GameObject HitEffectPrefab;
    public Transform ShootPoint;

    public float ShootDelay = 0.1f;
    public float MaxDistance = 100f;

    public UnityEvent<Vector3> OnShootSuccess;
    public UnityEvent OnShootFail;

    private void Start()
    {
        Stop();
    }

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        var WFS = new WaitForSeconds(ShootDelay);

        while (true)
        {
            Shoot();
            yield return WFS;
        }
    }

    private void Shoot()
    {   
        // Raycast�� �浹 ����
        if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out RaycastHit HitInfo, MaxDistance, HittableMask))
        {
            Instantiate(HitEffectPrefab, HitInfo.point, Quaternion.identity); // �浹 ������ ����Ʈ(HitEffectPrefab)�� ����

            var HitObject = HitInfo.transform.GetComponent<Hittable>();
            HitObject?.Hit(); // ��Ʈ ������Ʈ�� Hittable�� ���������� Hit �̺�Ʈ ����

            OnShootSuccess?.Invoke(HitInfo.point); // OnShootSuccess �̺�Ʈ(��������Ʈ)�� ��ϵǾ� �ִٸ�, �ش� �浹 ������ �����Ͽ� ȣ��
        }
        else
        {
            var HitPoint = ShootPoint.position + ShootPoint.forward * MaxDistance; //�浹�� ������, �ִ� �Ÿ����� ���ư� ������ HitPoint�� ���
            OnShootSuccess?.Invoke(HitPoint); // �� ���� ������ OnShootSuccess �̺�Ʈ�� ����
        }
    }
}
