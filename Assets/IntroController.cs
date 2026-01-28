using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "Gameplay";

    private bool isFinished = false;

    void Start()
    {
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.loopPointReached += OnVideoFinished;

        videoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        vp.Play();
        Debug.Log("Intro started");
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        if (isFinished) return;

        Debug.Log("Intro finished");
        isFinished = true;
        LoadNextScene();
    }

    void Update()
    {
        if (!isFinished && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Intro skipped by S key");
            isFinished = true;
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        videoPlayer.Stop();
        SceneManager.LoadScene(nextSceneName);
    }

    void OnDestroy()
    {
        videoPlayer.prepareCompleted -= OnVideoPrepared;
        videoPlayer.loopPointReached -= OnVideoFinished;
    }
}
