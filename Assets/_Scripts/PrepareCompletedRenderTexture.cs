﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrepareCompletedRenderTexture: MonoBehaviour
{
    public VideoClip videoClip;
    public RenderTexture renderTexture;

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    void Start()
    {
        SetupVideoAudioPlayers();
        
        // register method to invoke AFTER preparation is completed
        videoPlayer.prepareCompleted += PlayVideoWhenPrepared;
        
        // prepare video clip
        videoPlayer.Prepare();
        Debug.Log("A - PREPARING");
    }

    private void SetupVideoAudioPlayers()
    {
        // add video player and audio source components
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();

        // disable Play on Awake for both vide and audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;

        // assign video clip
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClip;

        // setup AudioSource 
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
        		
        // output video to RenderTexture
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;
    }

    
    private void PlayVideoWhenPrepared(VideoPlayer theVideoPlayer)
    {
        Debug.Log("B - IS PREPARED");

        // Play video
        Debug.Log("C - PLAYING");
        theVideoPlayer.Play();
    }
}
