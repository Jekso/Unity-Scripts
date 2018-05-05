using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerManager : MonoBehaviour {

    // private objects
	VideoPlayer videoComponent;
    string currentMinutes, currentSeconds, totalMinutes, totalSeconds;
    int videoClipIndex;
    

    // public objects
    public VideoClip[] playList;



    // init vars
	void Awake()
    {
        videoComponent = this.GetComponent<VideoPlayer>();
        videoClipIndex = 0;
        videoComponent.clip = playList[videoClipIndex];
	}



    // this function toggles between playing/pausing the video.
	public void TogglePlayPause()
    {
        if (!videoComponent.isPlaying)
        {
            videoComponent.Play();
        }
        else
        {
            videoComponent.Pause();
        }
	}



    // this function plays the next video_clip from the PlayList.
    public void PlayNextClip()
    {
        // increment the video index
        videoClipIndex++;

        // if the video index > playlist.length, make sure to recycle it again.
        if (videoClipIndex >= playList.Length)
            videoClipIndex = videoClipIndex % playList.Length;

        // change the video player clip and play it.
        videoComponent.clip = playList[videoClipIndex];
        videoComponent.Play();
    }



    // this function plays a clip from url.
    public void PlayFromURL(string url)
    {
        // TODO
    }



    // this function returns the curruent playing video seek time.
    public string GetVideoClipSeekTime()
    {
        // calculate minutes.
        currentMinutes = Mathf.Floor((int)videoComponent.time / 60).ToString("00");

        // calculate seconds.
        currentSeconds = ((int) videoComponent.time % 60).ToString("00");
        
        // return seek time.
        return currentMinutes + ":" + currentSeconds;
    }



    // this function returns the curruent playing video total time.
    public string GetVideoClipTotalTime()
    {
        // calculate minutes.
        totalMinutes = Mathf.Floor((int)videoComponent.clip.length / 60).ToString("00");

        // calculate seconds.
        totalSeconds = ((int)videoComponent.clip.length % 60).ToString("00");

        // return total time.
        return totalMinutes + ":" + totalSeconds;
    }
    
}
