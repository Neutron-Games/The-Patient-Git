using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    GameObject visualPadLock;
    public Transform lockCamera;
    public float duration;
    bool shouldInspect;
    private void Update()
    {
        if (shouldInspect)
        {
            if (Vector3.Distance(visualPadLock.transform.position, lockCamera.position) > .01f)
            {
                visualPadLock.transform.position = Vector3.Lerp(visualPadLock.transform.position, lockCamera.position, Time.deltaTime / duration);
                visualPadLock.transform.rotation = Quaternion.Lerp(visualPadLock.transform.rotation, lockCamera.rotation, Time.deltaTime / duration);
                visualPadLock.transform.localScale = Vector3.Lerp(visualPadLock.transform.localScale, Vector3.one * 2.5f, Time.deltaTime / duration);
            }
        }
    }

    public void isInspecting(GameObject padLock)
    {
        visualPadLock = padLock;
        shouldInspect = true;
    }
}
