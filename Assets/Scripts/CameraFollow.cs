using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smootSpeed = 0.04f;

    private void Start ()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp (transform.position, target.position + offset, smootSpeed);
        transform.position = newPos;
    }
}