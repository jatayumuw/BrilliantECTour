using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UILook : MonoBehaviour
{
    public GameObject blackTint;
    public Transform forward, pCamera, cameraOffset;
    public GameObject UICanvas;
    public MissionHandler missionHandler;
    public AudioSource[] audioSource;
    public GameObject[] navigationButton;
    public GameObject[] missionButton;
    public GameObject[] moveSceneButton;
    public GameObject[] canvasOpening;
    public GameObject progressBook;
    public GameObject instructionBook;

    void Awake()
    {
        missionHandler = GameObject.Find("Mission Handler").GetComponent<MissionHandler>();
        navigationButton = GameObject.FindGameObjectsWithTag("Navigation Button");
        missionButton = GameObject.FindGameObjectsWithTag("Mission Button");
        moveSceneButton = GameObject.FindGameObjectsWithTag("Move Scene Button");

        audioSource[0] = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        audioSource[1] = GameObject.FindGameObjectWithTag("Narrator").GetComponent<AudioSource>();

    }

    void Start()
    {
        for (int i = 0; i < missionButton.Length; i++)
        {
            int closureIndex = i;
            missionButton[closureIndex].GetComponent<Button>().onClick.AddListener(() => missionHandler.SetBoolMission(missionButton[closureIndex]));
        }
    }

    void Update()
    {
        for (int i = 0; i < canvasOpening.Length; i++)
        {
            if (canvasOpening[i].activeInHierarchy || UICanvas != null || progressBook.activeInHierarchy)
            {
                SetUpAllButton(false);
                if (missionHandler.levelIsDone)
                {
                    SetInteractableButton(moveSceneButton, false);
                }
                break;
            }
            else
            {
                SetUpAllButton(true);
                if (missionHandler.levelIsDone)
                {
                    SetInteractableButton(moveSceneButton, true);
                }

            }
        }
        forward.transform.eulerAngles = new Vector3(0, pCamera.eulerAngles.y, 0);
    }

    public void SetInteractableButton(GameObject[] buttonTarget, bool condition)
    {
        foreach (GameObject buttomTemp in buttonTarget)
        {
            buttomTemp.GetComponent<Button>().interactable = condition;
            buttomTemp.transform.parent.GetComponent<Animator>().enabled = condition;
        }
    }

    public void ShowBookProgression(GameObject canvasTarget)
    {
        if (UICanvas == null && canvasOpening[0].activeInHierarchy == false)
        {
            audioSource[0].volume = 0.25f;
            canvasTarget.SetActive(true);

            blackTint.SetActive(true);
            SetInteractableButton(navigationButton, false);
            SetInteractableButton(missionButton, false);
            SetInteractableButton(moveSceneButton, false);
        }
    }

    public void HideBookProgression(GameObject canvasTarget)
    {
        audioSource[0].volume = 1f;
        blackTint.SetActive(false);
        SetInteractableButton(navigationButton, true);
        SetInteractableButton(missionButton, true);
        SetInteractableButton(moveSceneButton, true);

        canvasTarget.SetActive(false);
        UICanvas = null;
    }

    public void ShowUICanvas(GameObject canvasTarget)
    {
        if (UICanvas == null && canvasOpening[0].activeInHierarchy == false && progressBook.activeInHierarchy == false) 
        {
            audioSource[0].volume = 0.25f;
            UICanvas = Instantiate(canvasTarget, cameraOffset);
            UICanvas.transform.eulerAngles = new Vector3(0, forward.eulerAngles.y, 0);

            blackTint.SetActive(true);
            SetInteractableButton(navigationButton, false);
            SetInteractableButton(missionButton, false);
            SetInteractableButton(moveSceneButton, false);
        }
    }

    public void CloseCanvasHandler(GameObject canvasTarget)
    {
        audioSource[0].volume = 1f;
        blackTint.SetActive(false);
        SetInteractableButton(navigationButton, true);
        SetInteractableButton(missionButton, true);
        SetInteractableButton(moveSceneButton, true);

        Destroy(canvasTarget);
        UICanvas = null;
    }

    public void MoveScene(string sceneTarget)
    {
        SceneManager.LoadScene(sceneTarget);
    }

    public void SetUpAllButton(bool cond)
    {
        SetInteractableButton(navigationButton, cond);
        SetInteractableButton(missionButton, cond);
        //if (missionHandler.levelIsDone)
        //{
        //    SetInteractableButton(moveSceneButton, cond);
        //}

    }

    public void DeleteCanvasOpening()
    {
        canvasOpening[0] = canvasOpening[1];
    }


}