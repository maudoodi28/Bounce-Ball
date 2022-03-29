using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonetizePanelScript : MonoBehaviour
{
    public static MonetizePanelScript instanceTime { get; private set; }
    public static MonetizePanelScript instancePause;
    public GameObject TextDisplay;
    public GameObject monetizePanel;
    public int SecondTime = 5;
    public int CountTime;
    public bool takingAway = false;
    public bool PauseDecrease = false;
    int x = 0;
    void Awake()
    {
        if (instanceTime == null)
        {
            instanceTime = this;
        }
        instancePause = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        TextDisplay.GetComponent<Text>().text = SecondTime + "s";
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && SecondTime > 0)
        {
            StartCoroutine(TimeTake());
            PrintTime();
        }
    }
    IEnumerator TimeTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1f);

        if (PauseDecrease == true)
        {
            SecondTime -= 1;
            TextDisplay.GetComponent<Text>().text = SecondTime + "s";
            takingAway = false;
        }

    }
    public void AdsBonus()
    {
        AdsScript.instanceAds1.ShowRewardedVideo();
        x = 1;
    }
    void PrintTime()
    {
        print(SecondTime);
        CountTime = SecondTime;
        if(CountTime==1 && x==0)
        {
            AdsScript.instanceAds1.ShowRewardedVideo();
        }
    }
    public void ResumeTime()
    {
        takingAway = false;
        PauseDecrease = true;
        print("true");
    }
}
