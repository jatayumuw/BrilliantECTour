using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconAnimation : MonoBehaviour
{
    public Transform sphere;
    public float frequency = 1f;
    public float distance = 1f;

    private Vector3 originalPosition;
    private Vector3 pointB;

    private void Start()
    {
        originalPosition = sphere.position;
        pointB = originalPosition + new Vector3(0, distance, 0);
    }

    private void Update()
    {
        if (distance == 0f)
        {
            return;
        }
        float t = Mathf.PingPong(Time.time * frequency, 1f);
        if (distance < 0f)
        {
            sphere.position = Vector3.Lerp(originalPosition, pointB, t);
        }
        else
        {
            sphere.position = Vector3.Lerp(originalPosition, pointB, t * 2f);
        }
    }
}





