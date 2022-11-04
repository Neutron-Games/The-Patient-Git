using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Transform canvas;


    // Raycast
    public Sprite[] points;
    Image lookPoint;
    Camera playerCamera;

    private RaycastHit interactedObject;


    // Inspecting
    Vector3 inspectingPoint;
    bool isInspecting = false;
    GameObject inspectingObject;

    private void Awake()
    {
        lookPoint = canvas.GetChild(0).GetComponent<Image>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        inspectingPoint = gameObject.transform.GetChild(2).gameObject.transform.position;


        if (IsInteractableObject())
        {
            lookPoint.sprite = points[1];
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                isInspecting = !isInspecting;
                if (isInspecting)
                {
                    interactedObject.collider.gameObject.GetComponent<Inspect>().InspectObject(inspectingPoint);
                    PlayerController.canMove = false;
                }
                else
                {
                    interactedObject.collider.gameObject.GetComponent<Inspect>().QuitInspect();
                    PlayerController.canMove = true;
                }
            }
        }

        else
        {
            lookPoint.sprite = points[0];
        }
        if (isInspecting && PlayerController.canMove == false && !IsInteractableObject() && Input.GetKeyDown(KeyCode.Mouse1))
        {
            isInspecting = !isInspecting;
            inspectingObject.GetComponent<Inspect>().QuitInspect();
            PlayerController.canMove = true;
        }
        if (isInspecting && PlayerController.canMove == false)
        {
            inspectingObject.GetComponent<Inspect>().RotateObject();
        }
    }

    public bool IsInteractableObject()
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