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
        // Raycast로 충돌 감지
        if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out RaycastHit HitInfo, MaxDistance, HittableMask))
        {
            Instantiate(HitEffectPrefab, HitInfo.point, Quaternion.identity); // 충돌 지점에 이펙트(HitEffectPrefab)를 생성

            var HitObject = HitInfo.transform.GetComponent<Hittable>();
            HitObject?.Hit(); // 히트 오브젝트가 Hittable를 갖고있으면 Hit 이벤트 실행

            OnShootSuccess?.Invoke(HitInfo.point); // OnShootSuccess 이벤트(델리게이트)가 등록되어 있다면, 해당 충돌 지점을 전달하여 호출
        }
        else
        {
            var HitPoint = ShootPoint.position + ShootPoint.forward * MaxDistance; //충돌이 없으면, 최대 거리까지 나아간 지점을 HitPoint로 계산
            OnShootSuccess?.Invoke(HitPoint); // 그 지점 정보를 OnShootSuccess 이벤트에 전달
        }
    }
}
