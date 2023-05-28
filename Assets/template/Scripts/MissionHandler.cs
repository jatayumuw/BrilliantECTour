using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[System.Serializable]
public class MissionDetail
{
    public bool isDone;
    public int missionId;
    public string missionTitle;
    public GameObject buttonMission;

    public void SetMission(int id, bool condition, string title, GameObject objek)
    {
        missionId = id;
        isDone = condition;
        missionTitle = title;
        buttonMission = objek;
    }
};

public class MissionHandler : MonoBehaviour
{
    static MissionHandler instance;

    public bool sortIsDone;
    public bool levelIsDone;
    public UILook uiManager;
    public List<MissionDetail> missionDetail;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
            instance = this;
        else
            DestroyObject(gameObject);

    }

    void Update()
    {
        if (uiManager == null)
        {
            missionDetail.Clear();
            uiManager = GameObject.Find("Scene Manager").GetComponent<UILook>();
            
            for (int i = 0; i < uiManager.missionButton.Length; i++)
            {
                string title = uiManager.missionButton[i].transform.parent.name;
                var mission = new MissionDetail();

                mission.SetMission(uiManager.missionButton[i].transform.parent.GetComponent<MissionIdentity>().missionId,
                                   false, title, uiManager.missionButton[i].transform.parent.gameObject);
                missionDetail.Add(mission);
            }

            missionDetail = missionDetail.OrderBy(w => w.missionId).ToList();
            sortIsDone = true;
        }

        if (sortIsDone)
            CheckMission();
    }

    public void CheckMission()
    {
        for (int i = 0; i < missionDetail.Count; i++)
            missionDetail[i].buttonMission.transform.GetChild(0).transform.Find("Button ID").GetComponent<TextMeshProUGUI>().text = missionDetail[i].missionId.ToString();

        for (int i = 0; i < missionDetail.Count; i++)
        {
            if (!missionDetail[i].isDone)
            {
                levelIsDone = false;
                break;
            }
            else
                levelIsDone = true;
        }

        for (int i = 0; i < uiManager.moveSceneButton.Length; i++)
        {
            if (levelIsDone)
            {
                uiManager.moveSceneButton[i].GetComponent<Button>().interactable = true;
                uiManager.moveSceneButton[i].transform.parent.GetComponent<Animator>().enabled = true;
            }
            else
            {
                uiManager.moveSceneButton[i].GetComponent<Button>().interactable = false;
                uiManager.moveSceneButton[i].transform.parent.GetComponent<Animator>().enabled = false;
            }
        }
    }

    public void SetBoolMission(GameObject button)
    {
        var parent = button.transform.parent;

        for (int i = 0; i < missionDetail.Count; i++)
            if (parent.name == missionDetail[i].buttonMission.name)
                missionDetail[i].isDone = true;
    }
}