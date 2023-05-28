using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoDestroyer : MonoBehaviour
{
    public void ResetVideo(GameObject video)
    {

        video.GetComponent<VideoPlayer>().targetTexture = null;
        //var source = video.GetComponent<VideoPlayer>().targetTexture;
        //DestroyImmediate(source, true);

    }
}
