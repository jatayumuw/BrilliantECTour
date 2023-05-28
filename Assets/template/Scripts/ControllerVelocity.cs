using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerVelocity : MonoBehaviour
{
    public InputActionProperty velocityProperty;

    public InputActionProperty runProperty;

    public GameObject rig;

    public Vector3 Velocity { get; private set; } = Vector3.zero;

    private void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
        
        if (runProperty.action.IsPressed())
        {
            rig.transform.forward = Velocity.normalized * Time.deltaTime;
        }
        
    }
}
