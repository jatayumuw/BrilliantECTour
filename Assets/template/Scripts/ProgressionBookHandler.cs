using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ProgressionBookHandler : MonoBehaviour
{
    public bool isPlay;
    public MissionHandler missionHandler;
    public UILook uiManager;
    public TextMeshProUGUI missionText;

    // Start is called before the first frame update
    void Update()
    {
        uiManager = GameObject.Find("Scene Manager").GetComponent<UILook>();
        missionHandler = GameObject.Find("Mission Handler").GetComponent<MissionHandler>();

        if (!isPlay && gameObject.activeInHierarchy)
        {
            for (int i = 0; i < missionHandler.missionDetail.Count; i++)
            {
                string markTemp = "";
                if (missionHandler.missionDetail[i].isDone)
                    markTemp = "V";
                else
                    markTemp = "?";

                missionText.text += $"{missionHandler.missionDetail[i].missionId}. [{markTemp}] {missionHandler.missionDetail[i].missionTitle}\n";
            }

            isPlay = true;
        }
    }

    public void CloseCanvasHandler()
    {
        uiManager.HideBookProgression(gameObject);

        missionText.text = "";
        isPlay = false;
    }
}