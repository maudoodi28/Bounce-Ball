using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighestScore : MonoBehaviour
{
    
    public GameObject ScorePanel;
    public GameObject MenuPanel;
    public Text ScoreHighest;
    public int Mscore;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        ScoreHighest.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        highestscore();
        Mscore = GameManager.MaxScore;
    }
    public void highestscore()
    {
        if (Mscore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", Mscore);
            ScoreHighest.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
    public void BackButton()
    {
        MenuPanel.SetActive(true);
        ScorePanel.SetActive(false);
    }
    public void MenuButton()
    {
        MenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
}
