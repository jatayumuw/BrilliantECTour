using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public GameObject myCam, originPos;
    [SerializeField] private bool changeScenePermission;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            myCam.transform.position = originPos.transform.position;
            SceneManager.LoadScene(sceneName);
            Debug.Log("Kenak Kolider");
        }

        if (collision.gameObject.CompareTag("Plane"))
        {
            Debug.Log("Kenak Kolider Plane");
        }
    }

    public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
