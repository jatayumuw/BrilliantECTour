using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScript : MonoBehaviour
{
    public bool isOpened = false;
    public GameObject blackTint;

    public void OpeningTwo()
    {
        //yield return new WaitForSeconds(1f);
        if (!isOpened)
        {
            blackTint.SetActive(true);
            this.gameObject.SetActive(true);
            isOpened = true;
        }
    }

}
