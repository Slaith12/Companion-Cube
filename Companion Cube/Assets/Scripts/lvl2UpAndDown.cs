using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2UpAndDown : MonoBehaviour
{
    public float speed;
    public Transform platform;
    public Transform targetB;
    public Transform targetA;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    void Start()
    {
        posA = targetA.localPosition;
        posB = targetB.localPosition;
        nextPos = posA;
    }

    void FixedUpdate()
    {
        platform.localPosition = Vector3.MoveTowards(platform.localPosition, nextPos, speed * Time.deltaTime);
        if(Vector3.Distance(platform.localPosition, nextPos) <=0.05)
        {
            nextPos = nextPos != posB ? posB : posA;
        }
    }
}
