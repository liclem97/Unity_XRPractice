using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    [Header("Ray")]
    public LineRenderer Ray;
    public LayerMask HitRayMask;
    public float Distance = 100f;

    [Header("Reticle Point")] 
    public GameObject ReticlePoint;
    public bool ShowReticle = true;

    private void Awake()
    {
        Off();
    }

    public void On()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Off()
    {
        StopAllCoroutines();
        Ray.enabled = false;
        ReticlePoint.SetActive(false);
    }

    private IEnumerator Process()
    {
        while (true)
        {   
            // LineTrace: ���� ��ġ, ����, HitResult, �Ÿ�, Layer
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit HitInfo, Distance, HitRayMask))
            {
                Ray.SetPosition(1, transform.InverseTransformPoint(HitInfo.point)); // ������ �� ���� HitInfo.Point�� �����ϵ� ���� ��ǥ -> ���� ��ǥ��
                Ray.enabled = true;

                ReticlePoint.transform.position = HitInfo.point; 
                ReticlePoint.SetActive(ShowReticle); // ���� ������ ���� �׸� �׸�
            }
            else
            {
                Ray.enabled = false;
                ReticlePoint.SetActive(false);
            }

            yield return null;
        }
    }
}
