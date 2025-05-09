using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;

    public bool PlayOnStart = true;
    public float StartFactor = 1f;
    public float AdditiveFactor = 0.1f;
    public float DelayPerSpawnGroup = 3f; // ���� �׷� ���������� �ð�

    private void Start() // ���� ����
    {
        if (PlayOnStart)
            Play();
    }

    public void Play()
    {
        StartCoroutine(Process()); // Process�� �ݺ�
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
            yield return WFS; // ���� �ð� ���

            yield return StartCoroutine(SpawnProcess(Factor)); // SpawnProcess �ݺ�

            Factor += AdditiveFactor;
        }
    }

    private IEnumerator SpawnProcess(float Factor)
    {
        var count = Random.Range(Factor, Factor * 2f); // �� ���� �� ���� ����

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
        Instantiate(Prefab, transform.position, transform.rotation, transform); // �� ��ȯ
    }
}
