using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pinpoint : MonoBehaviour
{
    public GameObject[] pinPoint = new GameObject[6];
    void Start()
    {
        for(int i = 0; i < pinPoint.Length; i++)
        {
            if (pinPoint[i].name == SceneManager.GetActiveScene().name) 
            {
                pinPoint[i].SetActive(true);
            }
        }
        
    }

}
