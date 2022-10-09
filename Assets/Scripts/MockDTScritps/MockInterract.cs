using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MockInterract : MonoBehaviour
{
    public Transform canvas;

    // RAYCAST
    public Sprite[] points;
    Image lookPoint;
    Camera playerCamera;


    private RaycastHit interactedObject;


    // inspecting
    Vector3 inspectingPoint;
    bool isInspecting = false;
    GameObject inspectingObject;



    private void Awake()
    {
        lookPoint = canvas.GetChild(0).GetComponent<Image>();
        playerCamera = GetComponentInChildren<Camera>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inspectingPoint = gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.position;


        if (IsInterractableObject())
        {
            lookPoint.sprite = points[1];
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                isInspecting = !isInspecting;
                if (isInspecting)
                {
                    interactedObject.collider.gameObject.GetComponent<Inspect>().InspectObject(inspectingPoint);
                    MouseLook.mouseSensitivity = 0f;

                }
                else
                {
                    interactedObject.collider.gameObject.GetComponent<Inspect>().QuitInspect();
                    MouseLook.mouseSensitivity = 500f;
                }
            }
        }
        else
        {
            lookPoint.sprite = points[0];
        }

        if (isInspecting && MouseLook.mouseSensitivity == 0f && !IsInterractableObject() && Input.GetKeyDown(KeyCode.Mouse1))
        {
            isInspecting = !isInspecting;
            inspectingObject.GetComponent<Inspect>().QuitInspect();
            MouseLook.mouseSensitivity = 500f;
        }

        if (isInspecting && MouseLook.mouseSensitivity == 0f)
        {
            inspectingObject.GetComponent<Inspect>().RotateObject();
        }

    }



    // incelenebilir obje olup olmadığını kontrol eder.
    public bool IsInterractableObject()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out interactedObject, 1.5f))
        {
            if (interactedObject.collider.gameObject.tag == "interactable")
            {
                inspectingObject = interactedObject.collider.gameObject;
                return true;
            }
        }
        return false;
    }


}
