using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI muteText;
    public static bool isGamePaused = false;

    public GameObject gamePausedPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
        {
            muteText.text = "/";
        }
        else
        {
            muteText.text = "";
        }

        //if (GameManager.pause)
        //{
        //    if (isGamePaused)
        //    {
        //        Resume();
        //    }
        //    else
        //    {
        //        Pause();
        //    }
        //}
    }


    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            muteText.text = "";
        }
        else
        {
            GameManager.mute = true;
            muteText.text = "/";
        }
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void TogglePause()
    {
            if (isGamePaused)
            {
                Resume();
            }
            else if (!GameManager.isGameOver && !isGamePaused)
            {
                Pause();
            }      
    }

    public void Resume()
        {
            // resume game
            gamePausedPanel.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        }

      public void Pause()
        {
            // pause game
           gamePausedPanel.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    

}