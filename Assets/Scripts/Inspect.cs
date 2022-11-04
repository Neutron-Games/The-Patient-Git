using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inspect : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;
    public float duration = 1f;
    public float inspectRatio = 2f;

    private void Awake()
    {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;
    }
    public void RotateObject()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * inspectRatio);
    }
    public void InspectObject(Vector3 inspectingPoint)
    {
        transform.position = Vector3.Lerp(transform.position, inspectingPoint, 10f);
    }

    public void QuitInspect()
    {
        transform.position = Vector3.Lerp(transform.position, initialPosition, 10f);
        transform.rotation = initialRotation;
    }
}