using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEventController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "Gameplay";
    public float autoLoadTime = 10f;

    void Start()
    {
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        vp.Play();
        Debug.Log("Video started");

        Invoke(nameof(LoadNextScene), autoLoadTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    void OnDestroy()
    {
        videoPlayer.prepareCompleted -= OnVideoPrepared;
    }
}
