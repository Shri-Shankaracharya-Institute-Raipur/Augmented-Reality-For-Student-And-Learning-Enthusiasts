using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class videoController : MonoBehaviour
{
    public GameObject videoPlayer;
    UnityEngine.Video.VideoPlayer player;
    public GameObject videoPlayerButtonContainer;
    public UnityEngine.UI.Button showVideoButton;
    public GameObject ImageTraget;
    public static GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
        videoPlayerButtonContainer.SetActive(false);    
        showVideoButton.gameObject.SetActive(false);
        player = videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>();
        

        if (player != null)
       {          
            player.Stop();          
       }
    }

    public void playListener()
    {
        player.Play();
    }

    public void pauseListener()
    {
        player.Pause();
    }
    public void resetListener()
    {
        player.Stop();
        player.Play();
    }

    public void showVideoPlayerListener()
    {
        videoPlayer.SetActive(true);
        videoPlayerButtonContainer.SetActive(true);
        player.Play();
    }


    public void ontragetLost()
    {
        videoPlayer.SetActive(false);
        showVideoButton.gameObject.SetActive(false);
        videoPlayerButtonContainer.SetActive(false);
        player.Stop();
    }

    public void ontragetFound()
    {
        showVideoButton.gameObject.SetActive(true);

    }

    public void on3DClicked(bool status)
    {
        if (!status)
        {
            Debug.LogError("Must be running: = " + ImageTraget);
            model = ImageTraget.transform.GetChild(0).gameObject;

            SceneManager.LoadScene(1);    
            
        }            
        else
            SceneManager.LoadScene(0);
    }
}
