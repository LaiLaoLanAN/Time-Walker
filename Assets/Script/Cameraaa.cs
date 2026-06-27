using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Cameraaa : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;

    private Coroutine CameraCoroutine;
    public float Duation;
    public AnimationCurve CCurve;
    // Start is called before the first frame update
    void Start()
    {
        vcam=GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Camearaf(float target)
    {
        if (CameraCoroutine != null)
        {
            StopCoroutine(CameraCoroutine);
        }
        CameraCoroutine = StartCoroutine(CameraI(target));
    }
    IEnumerator CameraI(float target)
    {
        float CurrentL = vcam.m_Lens.OrthographicSize;
        float timer= 0f;
        while (timer < Duation)
        {
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(CurrentL, target, CCurve.Evaluate(timer / Duation));
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
