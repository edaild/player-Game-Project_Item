using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
