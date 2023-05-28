using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InteractionSliderHandler : MonoBehaviour
{
    [System.Serializable]
    public class ContentDetail
    {
        public bool isVideo;
        public GameObject contentCanvas;
        public GameObject thumbnailCanvas;
    };

    [Header("Panel Attributes")]
    public bool thereIsObject;
    public TextMeshProUGUI descriptionText;
    public Texture thumbnailVideoSprite;
    public RawImage thumbnailVideo;
    public Texture thumbnailObjectSprite;
    public RawImage thumbnailObject;
    public VideoClip videoClip;
    public VideoPlayer videoPlayer;

    [Header("General Attributes")]
    public int contentIndex;
    public UILook uiManager;
    public List<GameObject> buttonCanvas;
    public List<ContentDetail> contentDetails;

    // Start is called before the first frame update
    void Start()
    {
        descriptionText.text = gameObject.name.Replace("(Clone)", "");
        thumbnailVideo.texture = thumbnailVideoSprite;
        videoPlayer.clip = videoClip;

        if (thereIsObject)
            thumbnailObject.texture = thumbnailObjectSprite;

        uiManager = GameObject.Find("Scene Manager").GetComponent<UILook>();
        contentDetails[0].thumbnailCanvas.GetComponent<Animator>().SetTrigger("RightToCenter");
    }

    // Update is called once per frame
    void Update()
    {
        SetupButton();
        for (int i = 0; i < contentDetails.Count; i++)
        {
            if (i == contentIndex && contentDetails[i].contentCanvas.transform.localScale.x <= 0)
            {
                contentDetails[i].contentCanvas.GetComponent<Animator>().ResetTrigger("isScaleDown");
                contentDetails[i].contentCanvas.GetComponent<Animator>().SetTrigger("isScaleUp");

                if (contentDetails[i].isVideo)
                    contentDetails[i].contentCanvas.transform.Find("Video Player").GetComponent<VideoPlayer>().Play();
            }
            else if (i != contentIndex && contentDetails[i].contentCanvas.transform.localScale.x >= 1)
            {
                contentDetails[i].contentCanvas.GetComponent<Animator>().ResetTrigger("isScaleUp");
                contentDetails[i].contentCanvas.GetComponent<Animator>().SetTrigger("isScaleDown");

                if (contentDetails[i].isVideo)
                    contentDetails[i].contentCanvas.transform.Find("Video Player").GetComponent<VideoPlayer>().Pause();
            }
        }
    }

    public void SetupButton()
    {
        if (contentIndex == 0)
        {
            buttonCanvas[0].SetActive(false);
            buttonCanvas[1].SetActive(true);
        }
        else if (contentIndex == contentDetails.Count - 1)
        {
            buttonCanvas[0].SetActive(true);
            buttonCanvas[1].SetActive(false);
        }
        else
        {
            buttonCanvas[0].SetActive(true);
            buttonCanvas[1].SetActive(true);
        }
    }

    public void PlaybackVideoFromStart(GameObject repeatButton)
    {
        var parent = repeatButton.transform.parent;
        parent.transform.Find("Video Player").GetComponent<VideoPlayer>().time = 0;
    }

    public void ChangeContentCanvas(int factor)
    {
        contentIndex += factor;

        if (factor < 0)
        {
            contentDetails[contentIndex + 1].thumbnailCanvas.GetComponent<Animator>().SetTrigger("CenterToRight");
            contentDetails[contentIndex].thumbnailCanvas.GetComponent<Animator>().SetTrigger("LeftToCenter");
        }
        else if (factor > 0)
        {
            contentDetails[contentIndex - 1].thumbnailCanvas.GetComponent<Animator>().SetTrigger("CenterToLeft");
            contentDetails[contentIndex].thumbnailCanvas.GetComponent<Animator>().SetTrigger("RightToCenter");
        }
    }

    public void CloseCanvasHandler()
    {
        uiManager.CloseCanvasHandler(gameObject);
    }
}
