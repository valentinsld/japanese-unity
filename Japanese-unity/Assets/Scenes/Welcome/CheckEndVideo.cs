using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CheckEndVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        StartCoroutine(EndCam(videoPlayer));
    }

    public IEnumerator EndCam(VideoPlayer video) {
        yield return new WaitForSeconds(23);

        Debug.LogWarning("END");
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync("Welcome");
        AsyncOperation asyncLoad1 = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Additive);
        AsyncOperation asyncLoad3 = SceneManager.LoadSceneAsync("BasicScene", LoadSceneMode.Additive);
        AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("Scene1_room", LoadSceneMode.Additive);

        //Done Playing
    }
}
