using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class SwingingArmMotion : MonoBehaviour
{
    public UILook uiManager;
    public GameObject progressionBookPrefab;

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject centerEyeCamera;
    public GameObject forwardDir;
    public GameObject instructionPrefab;


    private Vector3 positionPreviousFrameLeftHand;
    private Vector3 positionPreviousFrameRightHand;
    private Vector3 playerPositionPreviousFrame;
    private Vector3 playerPositionThisFrame;
    private Vector3 positionThisFrameLeftHand;
    private Vector3 positionThisFrameRightHand;

    public InputActionProperty rightHandInput, leftHandInput;
    public InputActionProperty rightHandBook, leftHandBook;

    public float speed = 20;
    private float handSpeed;

    private void Start()
    {
        uiManager = GameObject.Find("Scene Manager").GetComponent<UILook>();

        playerPositionPreviousFrame = transform.position;
        positionPreviousFrameLeftHand = leftHand.transform.position;
        positionPreviousFrameRightHand = rightHand.transform.position;
    }

    private void Update()
    {
         
        //leftHandClick.TryGetFeatureValue(CommonUsages.primaryButton, out bool leftPrimaryButtonValue);
        //rightHandClick.TryGetFeatureValue(CommonUsages.primaryButton, out bool rightPrimaryButtonValue);

        if (leftHandInput.action.IsPressed() && rightHandInput.action.IsPressed())
        {
            uiManager.ShowBookProgression(progressionBookPrefab);

            //float yRot = centerEyeCamera.transform.eulerAngles.y;
            //forwardDir.transform.eulerAngles = new Vector3(0, yRot, 0);

            //positionThisFrameLeftHand = leftHand.transform.position;
            //positionThisFrameRightHand = rightHand.transform.position;
            //playerPositionThisFrame = transform.position;

            //var playerDistanceMoved = Vector3.Distance(playerPositionThisFrame, playerPositionPreviousFrame);
            //var leftHandDistanceMoved = Vector3.Distance(positionThisFrameLeftHand, positionPreviousFrameLeftHand);
            //var rightHandDistanceMoved = Vector3.Distance(positionThisFrameRightHand, positionPreviousFrameRightHand);

            //handSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));


            //if (Time.timeSinceLevelLoad > 1f)
            //{
            //    transform.position += forwardDir.transform.forward * handSpeed * speed * Time.deltaTime;
            //}

            //positionPreviousFrameLeftHand = positionThisFrameLeftHand;
            //positionPreviousFrameRightHand = positionThisFrameRightHand;

            //playerPositionPreviousFrame = playerPositionThisFrame;
        }

        if (leftHandBook.action.IsPressed() && rightHandBook.action.IsPressed())
        {
            uiManager.ShowUICanvas(instructionPrefab);
        }


    }

}
