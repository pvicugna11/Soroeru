using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform TargetTransform;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        transform.RotateAround(TargetTransform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
