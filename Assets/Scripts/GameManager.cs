using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverPanel;
    public GameObject startMenuPanel;
    public GameObject gamePlayPanel;
    public GameObject gamePausedPanel;
    public static bool mute = false;
    public static bool pause = false;
    public static bool isTimeUp;
    public static float score = 0;

    public bool isDead { get; set; }


    public static bool isGameStarted;
    
    private PlayerController playerController;

    //UI and UI fields
    public TextMeshProUGUI scoreText, timeValue, coinText;
    


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isGameStarted = false;
        isTimeUp = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);

        }
        if (isGameOver) {
            Time.timeScale = 0;
            //isGameStarted = true;
            gameOverPanel.SetActive(true);
            startMenuPanel.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1") && isGameStarted)
        {
            SceneManager.LoadScene("Game");
            isGameStarted=true;
        }

        if (isTimeUp)
        {
            // stop the game by stopping the time
            Time.timeScale = 0;
            //timeUpPanel.SetActive(true);

            //reload the level 
            if (Input.GetButtonDown("Fire1"))
            {
                //// check if there is a new highscore 
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    // set player score to high score
                    //PlayerPrefs.SetInt("HighScore", score);
                }
                // reset the score on game over
                score = 0;
                SceneManager.LoadScene("Level");
            }
        }

        if(isGameStarted && !isGameOver)
        {
            score += (Time.deltaTime);
            scoreText.text = "Score:" + score.ToString();
            Debug.Log(scoreText.text);
        }
    }

    public void UpdateScores()
    {
        //scoreText.text = score.ToString();
        //coinText.text = coinScore.ToString();
        //timeValue.text = GameTimer.timeText.ToString();
    }
}
