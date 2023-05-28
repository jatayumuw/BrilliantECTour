using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera Camera2Follow;
    public float CameraDistance = 0.01F;
    public float smoothTime = 1F;
    private Vector3 velocity = Vector3.zero;
    private Transform target;

    void Awake()
    {

        target = Camera2Follow.transform;
    }


    void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {

        }

        else
        {
            // Define my target position in front of the camera ->
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, CameraDistance));

            // Smoothly move my object towards that position ->
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);


            // version 1: my object's rotation is always facing to camera with no dampening  ->
            transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);

            // version 2 : my object's rotation isn't finished synchronously with the position smooth.damp ->
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, smoothTime * Time.deltaTime);


            var lookAtPos = new Vector3(transform.position.x + Camera2Follow.transform.position.x, transform.position.y, Camera2Follow.transform.position.z);
            transform.LookAt(lookAtPos);
        }
        

        

    }
}
