using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingController : MonoBehaviour
{

    public bool isClimbing;
    bool inPosition;
    bool isLerping;

    float posT;
    float t;
    float climbDistance = 4f;
    float delta;

    Vector3 startPos;
    Vector3 targetPos;

    Quaternion startRot;
    Quaternion targetRot;

    public float posOffset;
    public float offsetFromWall = 0.3f;
    public float speedMultiplier = 0.2f;

    Transform helper;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;

        Tick(delta);
    }

    public void Tick(float delta)
    {
        if (!inPosition)
        {
            GetInPosition(delta);
            return;
        }
    }

    public void Init()
    {

        helper = new GameObject().transform;
        helper.name = "ClimbHelper";

        checkForClimb();
    }

    public void checkForClimb()
    {
        Vector3 origin = transform.position;
        Vector3 dir = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(origin, dir, out hit, climbDistance))
        {
            InitForClimb(hit);
        }

    }

    void InitForClimb(RaycastHit hit)
    {
        isClimbing = true;
        helper.transform.rotation = Quaternion.LookRotation(-hit.normal);
        startPos = transform.position;
        targetPos = hit.point + (hit.normal * offsetFromWall);
        t = 0;
        inPosition = false;
    }

    void GetInPosition(float delta)
    {
        t += delta;

        if(t > 1)
        {
            t = 1;
            inPosition = true;
        }

        Vector3 tp = Vector3.Lerp(startPos, targetPos, t);
        transform.position = tp;
    }

    Vector3 PosWithOffset( Vector3 origin, Vector3 target)
    {
        Vector3 dir = origin -target;
        dir.Normalize();
        Vector3 offset = dir * offsetFromWall;
        return target + offset;
    }

}
