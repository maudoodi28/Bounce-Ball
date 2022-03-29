using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager instance1;
    public static GameManager instancelife;
    public static GameManager instanceMonetizelife;
    public static int MaxScore;
    public int currentScore;
    public Text highestScore;
    public string HighScore;
    // public GameObject loseText;
    //public GameObject restart;
    public Text scoreText;
    public int score = 0;
    public bool gameover = true;
    public bool scoreup = true;
    bool Onlyscore = true;
    bool OnlyLife = true;
    bool OnlyPause = true;
    public bool monetize = true;
    int monetizeTime = 0;
    public GameObject GameOverPanel;
    public GameObject PauseMenuPanel;
    public GameObject ResumePanel;
    public GameObject LifePanel;
    public GameObject MonetizePanel;
    public int lives=3;
    int Xlives = 0;
    int x = 0;
    int extralife = 0;
    int Xlife;
    //bool gameOver = false;

    private void Awake()
    {
       // if(instancelife==null)
        //{
            instancelife = this;
       // }
        instance = this;
        instance1 = this;
        instanceMonetizelife = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      // MaxScore = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(monetizeTime==1 && x==0)
        {

            MonetizePanelScript.instancePause.ResumeTime();
            x++;
        }
        if(extralife==1)
        {
            LifePanel.transform.GetChild(Xlife).gameObject.SetActive(false);
            print("end");
            extralife++;
        }
    }


    public void ScoreUp()
    {
        if(scoreup == true && Onlyscore==true)
        {
            score++;
            MaxScore = score;
            
            if (score==10)
            {
                BallSpawner.instance.BQuantity--;
                BombSpawner.instance.BmQuantity++;
            }
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        if(monetize==true)
        {
            extralife = 1;
            Onlyscore = false;
            OnlyPause = false;
            GameOverPanel.SetActive(true);
            BallSpawner.instance.StopSpawningBall();
            BombSpawner.instance.StopSpawningBomb();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Pausemenu()
    {
        if(OnlyPause==true)
        {
            Onlyscore = false;
            OnlyLife = false;
            ResumePanel.SetActive(true);
            BallSpawner.instance.StopSpawningBall();
            BombSpawner.instance.StopSpawningBomb();
        }
        
    }
    public void ResumeButton()
    {
        Onlyscore = true;
        OnlyLife = true;
        ResumePanel.SetActive(false);
        BallSpawner.instance.StartSpawningBall();
        BombSpawner.instance.StartSpawningBomb();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ResumeMenuExit()
    {
        Application.Quit();
    }
    public void lifePanel()
    {
        if (lives > 0)
        {
            if(OnlyLife==true)
            {
                lives--;
                LifePanel.transform.GetChild(lives).gameObject.SetActive(false);
            }
            if(lives==0 && Xlives==0)
            {
                monetizePanel();
            }

        }
        if (lives <= 0)
        {
            gameover = false;
            GameOver();
        }
    }
    public void monetizePanel()
    {
        Xlives++;
        monetize = false;
        gameover = false;
        Onlyscore = false;
        OnlyLife = false;
        OnlyPause = false;
        MonetizePanel.SetActive(true);
        monetizeTime = 1;
        BallSpawner.instance.StartSpawningBall();
        BombSpawner.instance.StartSpawningBomb();
    }
    public void WinLife()
    {
        lives++;
        Xlife = lives;
        LifePanel.transform.GetChild(lives).gameObject.SetActive(true);
        
        MonetizePanel.SetActive(false);
        Onlyscore = true;
        OnlyLife = true;
        monetize = true;
        OnlyPause = true;
    }
    public void MonetizeCrossButton()
    {
        MonetizePanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
   
}
