using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{

    public GameObject xrRig;
    public Transform[] targetObjects;

    public void MoveXRigToTargetObject(int moveTo)
    {
        if (moveTo < targetObjects.Length)
        {
            Transform targetObject = targetObjects[moveTo];

            xrRig.transform.position = targetObject.position;

            moveTo++;
        }
        else
        {
            Debug.Log("No more target objects to move to.");
        }
    }
}
