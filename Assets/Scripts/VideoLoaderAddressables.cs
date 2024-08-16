using UnityEngine;
using UnityEngine.Video;

public class VideoLoaderAddressables : MonoBehaviour
{
    [SerializeField]
    private AssetReferenceVideoClip videoClipToLoad;
    [SerializeField]
    private VideoPlayer videoPlayer;

    private void Start()
    {
        AddressablesManager.LoadAsset<VideoClip>(videoClipToLoad, OnVideoLoaded);
    }

    private void OnVideoLoaded(VideoClip videoClip)
    {
        if (videoPlayer == null)
            return;

        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}
