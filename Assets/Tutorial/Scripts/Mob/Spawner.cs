using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;

    public bool PlayOnStart = true;
    public float StartFactor = 1f;
    public float AdditiveFactor = 0.1f;
    public float DelayPerSpawnGroup = 3f; // 다음 그룹 생성까지의 시간

    private void Start() // 게임 시작
    {
        if (PlayOnStart)
            Play();
    }

    public void Play()
    {
        StartCoroutine(Process()); // Process를 반복
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        var Factor = StartFactor;
        var WFS = new WaitForSeconds(DelayPerSpawnGroup);

        while (true)
        {
            yield return WFS; // 일정 시간 대기

            yield return StartCoroutine(SpawnProcess(Factor)); // SpawnProcess 반복

            Factor += AdditiveFactor;
        }
    }

    private IEnumerator SpawnProcess(float Factor)
    {
        var count = Random.Range(Factor, Factor * 2f); // 적 스폰 수 랜덤 지정

        for (int i = 0; i < count; i++)
        {
            Spawn();
            
            if (Random.value < 0.2f)
            {
                yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
            }
        }
    }

    private void Spawn()
    {
        Instantiate(Prefab, transform.position, transform.rotation, transform); // 몹 소환
    }
}
