using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : MonoBehaviour
{
    Vector3 globalLocation;
    Transform globalRotation;

    bool isInspect = false;

    private void Awake()
    {
        globalLocation = gameObject.GetComponent<Transform>().position;
        globalRotation = gameObject.GetComponent<Transform>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InspectObject(Vector3 inspectPos)
    {
        transform.position = Vector3.Lerp(transform.position, inspectPos, 1.0f);
    }
    public void QuitInspect()
    {
        transform.position = Vector3.Lerp(transform.position, globalLocation, 1.0f);
        transform.rotation = Quaternion.Euler(globalRotation.rotation.x, globalRotation.rotation.y, globalRotation.rotation.z);
    }

    public void RotateObject()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * 5);
    }
}
