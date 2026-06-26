using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juke : MonoBehaviour
{
    public Transform Player;
    private Vector3 velocity;
    public float smoothTime;
    [Header("Y谐振运动")]
    public float YAmplitude;
    public float YPeriod;
    public Vector3 Offset;
    private Vector3 smoothedBasePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 baseTarget = Player.position + Offset;
        smoothedBasePosition = Vector3.SmoothDamp(
            smoothedBasePosition,
            baseTarget,
            ref velocity,
            smoothTime
        );

        // 2. 独立计算Y谐振（不受平滑影响）
        float Yoffset = YAmplitude * Mathf.Sin((2f * Mathf.PI / YPeriod) * Time.time);

        // 3. 组合最终位置
        transform.position = smoothedBasePosition + new Vector3(0, Yoffset, 0);
    }
}
