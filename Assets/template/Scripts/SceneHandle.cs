using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneHandle : MonoBehaviour
{
    public GameObject cameraGroup;
    public GameObject sphereTarget;
    public GameObject blackFade;
    public bool isRotate;

    void Update()
    {
        if (blackFade.GetComponent<Image>().color.a >= 1)
        {
            if (isRotate)
                cameraGroup.transform.localRotation = Quaternion.Euler(0, -90, 0);

            cameraGroup.transform.position = sphereTarget.transform.position;
            blackFade.GetComponent<Animator>().SetTrigger("isFadingOut");
        }
    }

    public void ChangeSphereByGameobject(GameObject sphere)
    {
        sphereTarget = sphere;
        blackFade.GetComponent<Animator>().ResetTrigger("isFadingOut");
        blackFade.GetComponent<Animator>().SetTrigger("isFadingIn");
    }
}
