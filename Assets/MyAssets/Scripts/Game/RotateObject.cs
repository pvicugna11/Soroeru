using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private Vector3 startPosition;
    public RotateScriptableObject RotateData;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -startPosition.y)
        {
            transform.position = startPosition;
        }

        transform.Rotate(RotateData.RotateSpeed * Time.deltaTime, RotateData.RotateSpeed * Time.deltaTime, RotateData.RotateSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * RotateData.FallSpeed * Time.deltaTime, Space.World);
    }
}
