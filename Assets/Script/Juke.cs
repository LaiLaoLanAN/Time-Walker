using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juke : MonoBehaviour
{
    public MCscript MC;
    private Transform Player;

    public float smoothTime;
    public AnimationCurve smoothCurve;
    private Coroutine SmoothCorotine;
    public float MaxXOffset;
    public Vector3 Offset;
    private float LastDirection = 1;
    [Header("Y谐振运动")]
    public float YAmplitude;
    public float YPeriod;
    // Start is called before the first frame update
    void Start()
    {
        Player = MC.transform;
        Offset.x = -MaxXOffset * LastDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (MC.LocalScaleLock != LastDirection)
        {
            LastDirection = MC.LocalScaleLock;
            transform.localScale = new Vector2(LastDirection,1);
            if (SmoothCorotine != null)
            {
                StopCoroutine(SmoothCorotine);
            }
            SmoothCorotine = StartCoroutine(Smooth());
        }
        float Yoffset = YAmplitude * Mathf.Sin((2f * Mathf.PI / YPeriod) * Time.time);

        transform.position = Player.position + Offset + new Vector3(0, Yoffset, 0);
    }
    IEnumerator Smooth()
    {
        float TargetX = -LastDirection * MaxXOffset;
        float OriginX = Offset.x;
        float timer = 0f;
        while (timer < smoothTime)
        {
            Offset.x = Mathf.Lerp(OriginX, TargetX, smoothCurve.Evaluate(timer / smoothTime));
            timer += Time.deltaTime;
            yield return null;
        }
        Offset.x = TargetX;
    }
}
