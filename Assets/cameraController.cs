using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;

    public float speed;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA;
        target = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vecToTarget = target - transform.position;

        Vector3 frameVec = vecToTarget.normalized * Time.deltaTime * speed;

        if (vecToTarget.magnitude > frameVec.magnitude)
        {
            transform.position += frameVec;
        }
    }
}
