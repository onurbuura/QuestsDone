using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Point[] Targets;
    Point activeTarget;
    float Speed = 0f;
    [SerializeField] float time = 60f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        activeTarget = Targets[0];
        SetPath();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(activeTarget.transform, Vector3.right);
        rb.velocity = transform.forward * Speed;
    }

    void SetPath()
    {
        float dist = Vector3.Distance(transform.position, activeTarget.transform.position);
        Speed = dist / time;
    }

    void ChangeActiveTarget(Point point)
    {
        switch (point.point)
        {
            case PointType.A:
                activeTarget = Targets[1];
                break;

            case PointType.B:
                activeTarget = Targets[0];
                break;
        }

        SetPath();
    }

    void OnCollisionEnter(Collision col)
    {

        Point point = col.transform.GetComponent<Point>();

        if (point == null && activeTarget != point)
            return;

        ChangeActiveTarget(point);
    }
}
